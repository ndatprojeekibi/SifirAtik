using SifirAtik.Services.Services;

namespace SifirAtik.Server.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            string? header = context.Request.Headers["Authorization"].FirstOrDefault();

            if(!string.IsNullOrWhiteSpace(header))
            {
                // userService.token = header;
            }

            await _next(context);
        }
    }
}
