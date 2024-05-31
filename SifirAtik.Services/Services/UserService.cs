using SifirAtik.Data.Repositories;
using SifirAtik.Domain.Entities;
using SifirAtik.Domain.Dtos;
using SifirAtik.Domain.Dtos.Base;
using SifirAtik.Common.ResultItems;
using AutoMapper;

namespace SifirAtik.Services.Services
{
    public sealed class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<ResultItem> CreateAsync(BaseDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultItem> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var dtos = users.Select(user => _mapper.Map<GetUserDto>(user));

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
                var user = await _userRepository.GetByIdAsync(guid);

                if(user == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "User not found.",
                        Data = null
                    };
                }

                var dto = _mapper.Map<GetUserDto>(user);

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
                var userDto = _mapper.Map<User>(dto);
                var user = await _userRepository.GetByIdAsync(userDto.Guid);

                if (user == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "User not found.",
                        Data = null
                    };
                }

                user = _mapper.Map(dto, user);
                user.UpdatedAt = DateTime.Now;

                await _userRepository.UpdateAsync(user);
                var updated = _mapper.Map<GetUserDto>(user);

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

        public async Task<ResultItem> DeleteAsync(BaseDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
