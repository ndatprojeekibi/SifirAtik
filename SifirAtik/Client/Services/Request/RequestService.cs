using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;
using System;
using System.Net.Http.Json;

namespace SifirAtik.Client.Services.Request
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _http;

        public RequestService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<ResultItem> CreateAsync(CreateRequestDto createRequestDto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/request/Create", createRequestDto);

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

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = response.Message,
                    Data = null
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

        public Task<ResultItem> DeleteAsync(DeleteRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> GetAllAdoptionRequestsAsync()
        {
            try
            {
                var result = await _http.GetAsync($"/api/request/GetAllAdoptionRequests");

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

        public Task<ResultItem> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> GetAllDonationRequestsAsync()
        {
            try
            {
                var result = await _http.GetAsync($"/api/request/GetAllDonationRequests");

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

        public Task<ResultItem> GetByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> GetUserAdoptionRequestsById(Guid guid)
        {
            try
            {
                var result = await _http.GetAsync($"/api/request/GetUserAdoptionRequestsById/{guid}");

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

        public async Task<ResultItem> GetUserDonationRequestsById(Guid guid)
        {
            try
            {
                var result = await _http.GetAsync($"/api/request/GetUserDonationRequestsById/{guid}");

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

        public async Task<ResultItem> UpdateAsync(UpdateRequestDto dto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/request/Update", dto);

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
