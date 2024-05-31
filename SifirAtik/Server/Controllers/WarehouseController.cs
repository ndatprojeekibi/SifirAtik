using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SifirAtik.Domain.Dtos;
using SifirAtik.Services.Services;

namespace SifirAtik.Server.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/warehouse")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateWarehouseDto createWarehouseDto)
        {
            return Ok(await _warehouseService.CreateAsync(createWarehouseDto));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _warehouseService.GetAllAsync());
        }

        [HttpGet("GetNames")]
        public async Task<IActionResult> GetNames()
        {
            return Ok(await _warehouseService.GetNames());
        }

        [HttpGet("GetById/{guid}")]
        public async Task<IActionResult> GetById(Guid guid)
        {
            return Ok(await _warehouseService.GetByIdAsync(guid));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateWarehouseDto updateWarehouseDto)
        {
            return Ok(await _warehouseService.UpdateAsync(updateWarehouseDto));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(DeleteWarehouseDto deleteWarehouseDto)
        {
            return Ok(await _warehouseService.DeleteAsync(deleteWarehouseDto));
        }

    }
}
