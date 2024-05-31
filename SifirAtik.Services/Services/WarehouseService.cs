using AutoMapper;
using SifirAtik.Common.ResultItems;
using SifirAtik.Data.Repositories;
using SifirAtik.Domain.Dtos;
using SifirAtik.Domain.Dtos.Base;
using SifirAtik.Domain.Entities;

namespace SifirAtik.Services.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IMapper _mapper;
        private readonly WarehouseRepository _warehouseRepository;
        private readonly UserRepository _userRepository;

        public WarehouseService(WarehouseRepository warehouseRepository, IMapper mapper, UserRepository userRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
            _userRepository = userRepository;
        }

        public async Task<ResultItem> CreateAsync(BaseDto dto)
        {
            try
            {
                var warehouse = _mapper.Map<Warehouse>(dto);

                warehouse.Guid = Guid.NewGuid();
                warehouse.UpdatedById = warehouse.CreatedById;
                warehouse.CreatedAt = DateTime.Now;
                warehouse.UpdatedAt = DateTime.Now;

                await _warehouseRepository.CreateAsync(warehouse);

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

        public async Task<ResultItem> GetAllAsync()
        {
            try
            {
                var items = await _warehouseRepository.GetAllAsync();
                var dtos = items.Select(item => _mapper.Map<GetWarehouseDto>(item));

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
                var item = await _warehouseRepository.GetByIdAsync(guid);

                if (item == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "Item not found.",
                        Data = null
                    };
                }

                var dto = _mapper.Map<GetWarehouseDto>(item);

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

        public async Task<ResultItem> GetNames()
        {
            try
            {
                var items = await _warehouseRepository.GetAllAsync();
                var dtos = items.Select(item => _mapper.Map<GetWarehouseNamesDto>(item));

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
                var warehouseDto = _mapper.Map<Warehouse>(dto);
                var user = await _userRepository.GetByIdAsync(warehouseDto.UpdatedById);

                if (user == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "User not found.",
                        Data = null
                    };
                }

                var warehouse = await _warehouseRepository.GetByIdAsync(warehouseDto.Guid);

                if (warehouse == null)
                {
                    return new ResultItem
                    {
                        IsSuccess = false,
                        Message = "Warehouse not found.",
                        Data = null
                    };
                }

                warehouse = _mapper.Map(dto, warehouse);
                warehouse.UpdatedAt = DateTime.Now;

                await _warehouseRepository.UpdateAsync(warehouse);
                var updated = _mapper.Map<GetWarehouseDto>(warehouse);

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
    }
}
