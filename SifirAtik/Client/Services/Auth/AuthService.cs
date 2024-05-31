using Microsoft.AspNetCore.Components;
using SifirAtik.Client.Services.Auth;
using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;
using System.Net.Http.Json;
using System.Text.Json;

namespace SifirAtik.Client.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public AuthService(HttpClient http, ILocalStorageService localStorage, NavigationManager navigationManager)
        {
            _http = http;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        public async Task<ResultItem> LoginAsync(LoginUserDto loginUserDto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/auth/Login", loginUserDto);

                if (result == null || !result.IsSuccessStatusCode)
                {
                    return new ResultItem()
                    {
                        IsSuccess = false,
                        Message = "Error: An unexpected error occured.",
                        Data = null
                    };
                }

                var response = await result.Content.ReadFromJsonAsync<ResultItem>();

                if (response == null)
                {
                    return new ResultItem()
                    {
                        IsSuccess = false,
                        Message = "Error: An unexpected error occured.",
                        Data = null
                    };
                }

                if (!response.IsSuccess)
                {
                    return new ResultItem()
                    {
                        IsSuccess = false,
                        Message = $"Error: {response.Message}",
                        Data = null
                    };
                }

                var json = JsonSerializer.Serialize(response.Data);
                var token = JsonSerializer.Deserialize<string>(json);

                await _localStorage.SetItemAsync("token", token);

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = response.Message,
                    Data = token
                };
            }
            catch (Exception)
            {
                return new ResultItem()
                {
                    IsSuccess = false,
                    Message = "Error: An unexpected error occured.",
                    Data = null
                };
            }
        }

        public async Task<ResultItem> LogoutAsync()
        {
            try
            {
                await _localStorage.RemoveItemAsync("token");
                _navigationManager.NavigateTo("auth/login");

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Logout successfull.",
                    Data = null
                };
            }
            catch
            {
                return new ResultItem()
                {
                    IsSuccess = false,
                    Message = "Error: An unexpected error occured.",
                    Data = null
                };
            }
        }

        public async Task<ResultItem> RegisterAsync(RegisterUserDto registerUserDto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/auth/Register", registerUserDto);

                if (result == null || !result.IsSuccessStatusCode)
                {
                    return new ResultItem()
                    {
                        IsSuccess = false,
                        Message = "Error: An unexpected error occured.",
                        Data = null
                    };
                }

                var response = await result.Content.ReadFromJsonAsync<ResultItem>();

                if (response == null)
                {
                    return new ResultItem()
                    {
                        IsSuccess = false,
                        Message = "Error: An unexpected error occured.",
                        Data = null
                    };
                }

                if(!response.IsSuccess)
                {
                    return new ResultItem()
                    {
                        IsSuccess = false,
                        Message = $"Error: {response.Message}",
                        Data = null
                    };
                }

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = response.Message,
                    Data = null
                };
            }
            catch(Exception)
            {
                return new ResultItem()
                {
                    IsSuccess = false,
                    Message = "Error: An unexpected error occured.",
                    Data = null
                };
            }
        }

        public async Task<ResultItem> UpdatePasswordAsync(UpdatePasswordDto dto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/auth/UpdatePassword", dto);

                if (result == null || !result.IsSuccessStatusCode)
                {
                    return new ResultItem()
                    {
                        IsSuccess = false,
                        Message = "Error: An unexpected error occured.",
                        Data = null
                    };
                }

                var response = await result.Content.ReadFromJsonAsync<ResultItem>();

                if (response == null)
                {
                    return new ResultItem()
                    {
                        IsSuccess = false,
                        Message = "Error: An unexpected error occured.",
                        Data = null
                    };
                }

                if (!response.IsSuccess)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = $"Error: {response.Message}",
                        Data = null
                    };
                }

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = response.Message,
                    Data = response.Data
                };
            }
            catch (Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "Error: An unexpected error occured.",
                    Data = null
                };
            }    
        }
    }
}
