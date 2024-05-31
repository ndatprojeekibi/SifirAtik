using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;
using System;
using System.Net;
using System.Net.Http.Json;

namespace SifirAtik.Client.Services.Item
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _http;

        public ItemService(HttpClient httpClient) 
        {
            _http = httpClient;
        }

        public async Task<ResultItem> CreateAsync(CreateItemDto createItemDto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/item/Create", createItemDto);

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
                    Data = response.Data
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

        public Task<ResultItem> DeleteAsync(DeleteItemDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResultItem> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> UpdateAsync(UpdateItemDto dto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/item/Update", dto);

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

        public async Task<ResultItem> GetUserItemsById(Guid guid)
        {
            try
            {
                var result = await _http.GetAsync($"/api/item/GetUserItemsById/{guid}");

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

        public async Task<ResultItem> GetByIdAsync(Guid guid)
        {
            try
            {
                var result = await _http.GetAsync($"/api/item/GetById/{guid}");

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

        public async Task<ResultItem> GetMarketplace()
        {
            try
            {
                var result = await _http.GetAsync("/api/item/GetMarketplace");

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

        public async Task<ResultItem> GetMarketplaceItem(Guid guid)
        {
            try
            {
                var result = await _http.GetAsync($"/api/item/GetMarketplace/{guid}");

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

        public async Task<ResultItem> AcceptDonatedItem(AcceptDonatedItemDto dto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/api/item/AcceptDonatedItem", dto);

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
