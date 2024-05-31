using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace SifirAtik.Client.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public Task<ResultItem> CreateAsync(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResultItem> DeleteAsync(DeleteUserDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> GetAllAsync()
        {
            try
            {
                var result = await _http.GetAsync("/api/user/GetAll");

                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "Error: An unexpected error occured.",
                        Data = null
                    };
                }

                var response = await result.Content.ReadFromJsonAsync<ResultItem>();

                if (response == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = string.Empty,
                        Data = null
                    };
                }

                if(!response.IsSuccess)
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
            catch(Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "Error: An unexpected error occured.",
                    Data = null
                };
            }
        }

        public async Task<ResultItem> GetByIdAsync(Guid guid)
        {
            try
            {
                var result = await _http.GetAsync($"/api/user/GetById/{guid}");

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

        public async Task<ResultItem> UpdateAsync(UpdateUserProfileDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> UpdateUserProfileAsync(UpdateUserProfileDto dto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/user/UpdateUserProfile", dto);

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

        public async Task<ResultItem> UpdateEmailAsync(UpdateEmailDto dto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/user/UpdateEmail", dto);

                if (result == null || !result.IsSuccessStatusCode)
                {
                    return new ResultItem()
                    {
                        IsSuccess = false,
                        Message = string.Empty,
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
