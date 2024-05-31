using AutoMapper;
using SifirAtik.Common;
using SifirAtik.Common.Enums;
using SifirAtik.Common.ResultItems;
using SifirAtik.Data.Repositories;
using SifirAtik.Domain.Dtos;
using SifirAtik.Domain.Dtos.Base;
using SifirAtik.Domain.Entities;
using SifirAtik.Utils.JsonWebToken;
using SifirAtik.Utils.PasswordHash;
using System.Security.Claims;

namespace SifirAtik.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public AuthService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResultItem> LoginAsync(AuthDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null)
            {
                return new ResultItem()
                {
                    IsSuccess = false,
                    Message = "Account doesn't exist.",
                    Data = null
                };
            }

            if (!PasswordHashVerifier.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ResultItem()
                {
                    IsSuccess = false,
                    Message = "Incorrect account or password.",
                    Data = null
                };
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("UserId", user.Guid.ToString()),
                new Claim("Name", user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = TokenCreator.CreateToken(claims, AppSettings.SecretKey);

            return new ResultItem()
            {
                IsSuccess = true,
                Message = "Successfully logged in.",
                Data = token
            };
        }

        public async Task<ResultItem> RegisterAsync(AuthDto dto)
        {
            try
            {
                PasswordHashCreator.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var user = _mapper.Map<User>(dto);

                var guid = Guid.NewGuid();
                user.Guid = guid;
                user.CreatedAt = DateTime.UtcNow;
                user.UpdatedAt = DateTime.UtcNow;
                user.CreatedById = guid;
                user.UpdatedById = guid;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                // A user is considered basic user if they register with this service.
                user.Role = Role.User;

                await _userRepository.CreateAsync(user);

                return new ResultItem()
                {
                    IsSuccess = true,
                    Message = "Successfully registered.",
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

        public async Task<ResultItem> UpdatePasswordAsync(UpdatePasswordDto dto)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(dto.Guid);

                if(user == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "Account doesn't exist.",
                        Data = null
                    };
                }

                if(!PasswordHashVerifier.VerifyPasswordHash(dto.OldPassword, user.PasswordHash, user.PasswordSalt))
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "The old password is incorrect.",
                        Data = null
                    };
                }

                PasswordHashCreator.CreatePasswordHash(dto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

                user = _mapper.Map(dto, user);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.UpdatedAt = DateTime.Now;

                await _userRepository.UpdateAsync(user);

                return new ResultItem()
                {
                    IsSuccess = true,
                    Message = "Password updated successfully.",
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
