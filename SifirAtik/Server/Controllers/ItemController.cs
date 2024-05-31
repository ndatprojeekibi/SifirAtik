using SifirAtik.Domain.Dtos;
using SifirAtik.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SifirAtik.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/item")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateItemDto createItemDto)
        {
            return Ok(await _itemService.CreateAsync(createItemDto));
        }

        [HttpGet("GetAll"), Authorize(Roles = "Root, Admin")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _itemService.GetAllAsync());
        }

        [HttpGet("GetById/{guid}")]
        public async Task<IActionResult> GetById(Guid guid)
        {
            return Ok(await _itemService.GetByIdAsync(guid));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateItemDto updateItemDto)
        {
            return Ok(await _itemService.UpdateAsync(updateItemDto));
        }

        [HttpPost("AcceptDonatedItem")]
        public async Task<IActionResult> AcceptDonatedItem(AcceptDonatedItemDto acceptDonatedItemDto)
        {
            return Ok(await _itemService.UpdateAsync(acceptDonatedItemDto));
        }

        [HttpPost("Delete"), Authorize(Roles = "Root, Admin")]
        public async Task<IActionResult> Delete(DeleteItemDto deleteItemDto)
        {
            return Ok(await _itemService.DeleteAsync(deleteItemDto));
        }

        [HttpGet("GetUserItemsById/{guid}")]
        public async Task<IActionResult> GetUserItemsById(Guid guid)
        {
            return Ok(await _itemService.GetUserItemsByIdAsync(guid));
        }
        
        [HttpGet("GetMarketplace")]
        public async Task<IActionResult> GetMarketplace()
        {
            return Ok(await _itemService.GetMarketplace());
        }

        [HttpGet("GetMarketplace/{guid}")]
        public async Task<IActionResult> GetMarketplaceItem(Guid guid)
        {
            return Ok(await _itemService.GetMarketplaceItem(guid));
        }
    }
}
