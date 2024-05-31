using SifirAtik.Utils.JsonWebToken;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SifirAtik.Client.Services.Auth
{
    internal class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IAuthService _authService;
        private readonly HttpClient _http;

        public CustomAuthStateProvider(ILocalStorageService localStorageService, IAuthService authService, HttpClient http)
        {
            _localStorageService = localStorageService;
            _http = http;
            _authService = authService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Get the token from the local storage
            var token = await _localStorageService.GetItemAsStringAsync("token");
            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                var claims = TokenParser.ParseClaimsFromJwt(token);

                var expirationClaim = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp);
                if (expirationClaim != null)
                {
                    var expirationTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expirationClaim.Value));
                    if (expirationTime <= DateTimeOffset.UtcNow)
                    {
                        // Token has expired
                        await _authService.LogoutAsync();
                        return new AuthenticationState(new ClaimsPrincipal());
                    }
                }

                identity = new ClaimsIdentity(claims, "jwt");

                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
