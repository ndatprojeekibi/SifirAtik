using SifirAtik.Domain.Dtos;
using SifirAtik.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SifirAtik.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/request")]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateRequestDto createRequestDto)
        {
            return Ok(await _requestService.CreateAsync(createRequestDto));
        }

        [HttpGet("GetAll"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _requestService.GetAllAsync());
        }

        [HttpGet("GetById/{guid}")]
        public async Task<IActionResult> GetById(Guid guid)
        {
            return Ok(await _requestService.GetByIdAsync(guid));
        }

        [HttpGet("GetUserDonationRequestsById/{guid}")]
        public async Task<IActionResult> GetUserDonationRequestsById(Guid guid)
        {
            return Ok(await _requestService.GetUserDonationRequestsByIdAsync(guid));
        }

        [HttpGet("GetUserAdoptionRequestsById/{guid}")]
        public async Task<IActionResult> GetUserAdoptionRequestsById(Guid guid)
        {
            return Ok(await _requestService.GetUserAdoptionRequestsByIdAsync(guid));
        }

        [HttpGet("GetAllDonationRequests"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDonationRequests()
        {
            return Ok(await _requestService.GetAllDonationRequestsAsync());
        }

        [HttpGet("GetAllAdoptionRequests"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAdoptionRequests()
        {
            return Ok(await _requestService.GetAllAdoptionRequestsAsync());
        }

        [HttpPost("Update"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateRequestDto updateRequestDto)
        {
            return Ok(await _requestService.UpdateAsync(updateRequestDto));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(DeleteRequestDto deleteRequestDto)
        {
            return Ok(await _requestService.DeleteAsync(deleteRequestDto));
        }
    }
}
