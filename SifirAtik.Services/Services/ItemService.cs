using AutoMapper;
using SifirAtik.Common.ResultItems;
using SifirAtik.Data.Repositories;
using SifirAtik.Domain.Dtos;
using SifirAtik.Domain.Dtos.Base;
using SifirAtik.Domain.Entities;
using SifirAtik.Common.Enums;

namespace SifirAtik.Services.Services
{
    public class ItemService : IItemService
    {
        private readonly IMapper _mapper;
        private readonly ItemRepository _itemRepository;
        private readonly UserRepository _userRepository;
        private readonly RequestRepository _requestRepository;

        public ItemService(IMapper mapper, ItemRepository itemRepository, 
            UserRepository userRepository, RequestRepository requestRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            _requestRepository = requestRepository;
        }

        public async Task<ResultItem> CreateAsync(BaseDto dto)
        {
            try
            {
                var item = _mapper.Map<Item>(dto);

                var uncheckedRequestCount = await _requestRepository.GetUnapprovedRequestCountByUserIdAsync(item.CreatedById);

                if (uncheckedRequestCount >= 2)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = $"You have at least 2 unchecked requests. Please wait some time.",
                        Data = null
                    };
                }

                var user = await _userRepository.GetByIdAsync(item.CreatedById);

                if (user == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "User not found.",
                        Data = null
                    };
                }

                item.Guid = Guid.NewGuid();
                item.UpdatedById = item.CreatedById;
                item.CreatedAt = DateTime.Now;
                item.UpdatedAt = DateTime.Now;

                await _itemRepository.CreateAsync(item);
                var data = _mapper.Map<GetItemDto>(item);

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Operation successfull.",
                    Data = data
                };
            }
            catch (Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "An unexpected error occured.",
                    Data = null
                };
            }
        }

        public async Task<ResultItem> GetAllAsync()
        {
            try
            {
                var items = await _itemRepository.GetAllAsync();
                var dtos = items.Select(item => _mapper.Map<GetItemDto>(item));

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Operation successfull.",
                    Data = dtos
                };
            }
            catch (Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "An unexpected error occured.",
                    Data = null
                };
            }
        }

        public async Task<ResultItem> GetByIdAsync(Guid guid)
        {
            try
            {
                var item = await _itemRepository.GetByIdAsync(guid);

                if(item == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "Item not found.",
                        Data = null
                    };
                }

                var dto = _mapper.Map<GetItemDto>(item);

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Operation successfull.",
                    Data = dto
                };
            }
            catch (Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "An unexpected error occured.",
                    Data = null
                };
            }
        }

        public async Task<ResultItem> UpdateAsync(BaseDto dto)
        {
            try
            {
                var itemDto = _mapper.Map<Item>(dto);

                var user = await _userRepository.GetByIdAsync(itemDto.UpdatedById);

                if (user == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "User not found.",
                        Data = null
                    };
                }

                var item = await _itemRepository.GetByIdAsync(itemDto.Guid);

                if (item == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "Item not found.",
                        Data = null
                    };
                }

                if (user.Role == Role.User) 
                {
                    if(user.Guid != item.CreatedById)
                    {
                        return new ResultItem
                        {
                            IsSuccess = false,
                            Message = "This item is not yours. You can not edit this item.",
                            Data = null
                        };
                    }

                    var request = await _requestRepository.GetRequestByItemIdAsync(item.Guid);

                    if(request == null)
                    {
                        return new ResultItem
                        {
                            IsSuccess = false,
                            Message = "This item was created without an associated request. You cannot edit it.",
                            Data = null
                        };
                    }

                    if(request.IsApproved != ApproveType.NotChecked)
                    {
                        return new ResultItem
                        {
                            IsSuccess = false,
                            Message = "The request associated with this item has already been processed and the item cannot be edited.",
                            Data = null
                        };
                    }
                }

                item = _mapper.Map(dto, item);
                item.UpdatedAt = DateTime.Now;

                await _itemRepository.UpdateAsync(item);
                var updated = _mapper.Map<GetItemDto>(item);

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Updated successfully.",
                    Data = updated
                };
            }
            catch (Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "An unexpected error occured.",
                    Data = null
                };
            }
        }

        public Task<ResultItem> DeleteAsync(BaseDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> GetUserItemsByIdAsync(Guid guid)
        {
            try
            {
                var items = await _itemRepository.GetUserItemsByIdAsync(guid);
                var dtos = items.Select(item => _mapper.Map<GetItemDto>(item));

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Operation successfull.",
                    Data = dtos
                };

            }
            catch (Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "An unexpected error occured.",
                    Data = null
                };
            }
        }

        public async Task<ResultItem> GetMarketplace()
        {
            try
            {
                var items = await _itemRepository.GetMarketplace();
                var dtos = items.Select(item => _mapper.Map<MarketItemDto>(item));

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Operation successfull.",
                    Data = dtos
                };
            }
            catch (Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "An unexpected error occured.",
                    Data = null
                };
            }
        }

        public async Task<ResultItem> GetMarketplaceItem(Guid guid)
        {
            try
            {
                var item = await _itemRepository.GetByIdAsync(guid);

                if (item == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "Item not found.",
                        Data = null
                    };
                }

                var dto = _mapper.Map<MarketItemDto>(item);

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Operation successfull.",
                    Data = dto
                };
            }
            catch (Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "An unexpected error occured.",
                    Data = null
                };
            }
        }
    }
}
