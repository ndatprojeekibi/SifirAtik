using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace SifirAtik.Client.Services.Warehouse
{
    public class WarehouseService : IWarehouseService
    {
        private readonly HttpClient _http;

        public WarehouseService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResultItem> CreateAsync(CreateWarehouseDto dto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/warehouse/Create", dto);

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

        public async Task<ResultItem> DeleteAsync(DeleteWarehouseDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> GetAllAsync()
        {
            try
            {
                var result = await _http.GetAsync("/api/warehouse/GetAll");

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

        public async Task<ResultItem> GetByIdAsync(Guid guid)
        {
            try
            {
                var result = await _http.GetAsync($"/api/warehouse/GetById/{guid}");

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

        public async Task<ResultItem> GetNames()
        {
            try
            {
                var result = await _http.GetAsync("/api/warehouse/GetNames");

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

        public async Task<ResultItem> UpdateAsync(UpdateWarehouseDto dto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/warehouse/Update", dto);

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
