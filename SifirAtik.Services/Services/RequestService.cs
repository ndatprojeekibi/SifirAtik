using AutoMapper;
using SifirAtik.Common.ResultItems;
using SifirAtik.Data.Repositories;
using SifirAtik.Domain.Dtos;
using SifirAtik.Domain.Dtos.Base;
using SifirAtik.Domain.Entities;
using SifirAtik.Common.Enums;
using System;
using Microsoft.EntityFrameworkCore;

namespace SifirAtik.Services.Services
{
    public class RequestService : IRequestService
    {
        private readonly RequestRepository _requestRepository;
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public RequestService(RequestRepository requestRepository, IMapper mapper, UserRepository userRepository)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResultItem> CreateAsync(BaseDto dto)
        {
            try
            {
                var request = _mapper.Map<Request>(dto);

                if(request.ItemId == Guid.Empty)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "Can not create a request without an item.",
                        Data = null
                    };
                }

                var control = await _requestRepository.GetRequestByItemIdAndCreatedByIdAsync(request.ItemId, request.CreatedById);

                if(control != null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "You already have a request for this item.",
                        Data = null
                    };
                }

                request.Guid = Guid.NewGuid();
                request.UpdatedById = request.CreatedById;
                request.IsApproved = ApproveType.NotChecked;
                request.CreatedAt = DateTime.Now;
                request.UpdatedAt = DateTime.Now;

                await _requestRepository.CreateAsync(request);

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Operation successfull.",
                    Data = null
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

        public Task<ResultItem> GetAllAdoptionRequestsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultItem> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> GetAllDonationRequestsAsync()
        {
            try
            {
                var requests = await _requestRepository.GetAllDonationRequests();
                var requestList = await requests.ToListAsync();

                var userIds = requestList.Select(r => r.CreatedById).Distinct();

                var userNames = await _userRepository.GetUserNamesByIdsAsync(userIds);

                var dtos = requestList.Select(request => {
                    var dto = _mapper.Map<GetDonationRequestDto>(request);
                    dto.CreatedByName = userNames[request.CreatedById];
                    return dto;
                }).ToList();

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Operation successful.",
                    Data = dtos
                };
            }
            catch (Exception)
            {
                return new ResultItem
                {
                    IsSuccess = false,
                    Message = "An unexpected error occurred.",
                    Data = null
                };
            }
        }

        public Task<ResultItem> GetByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> GetUserAdoptionRequestsByIdAsync(Guid guid)
        {
            try
            {
                var requests = await _requestRepository.GetUserAdoptionRequestsByIdAsync(guid);
                var dtos = requests.Select(request => _mapper.Map<GetAdoptionRequestDto>(request)).ToList();

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

        public async Task<ResultItem> GetUserDonationRequestsByIdAsync(Guid guid)
        {
            try
            {
                var requests = await _requestRepository.GetUserDonationRequestsByIdAsync(guid);
                var dtos = requests.Select(request => _mapper.Map<GetDonationRequestDto>(request)).ToList();

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

        public async Task<ResultItem> UpdateAsync(BaseDto dto)
        {
            try
            {
                var requestDto = _mapper.Map<Request>(dto);
                var user = await _userRepository.GetByIdAsync(requestDto.UpdatedById);

                if (user == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "User not found.",
                        Data = null
                    };
                }

                var request = await _requestRepository.GetByIdAsync(requestDto.Guid);

                if (request == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "Item not found.",
                        Data = null
                    };
                }

                request = _mapper.Map(dto, request);
                request.UpdatedAt = DateTime.Now;

                await _requestRepository.UpdateAsync(request);

                return new ResultItem
                {
                    IsSuccess = true,
                    Message = "Updated successfully.",
                    Data = null
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
