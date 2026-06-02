using CalorieTracker.Application.DTO.FoodSuggestion;
using CalorieTracker.Application.Interfaces.Services;
using CalorieTracker.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CalorieTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/suggestions")]
    public class FoodSuggestionsController : ControllerBase
    {
        private readonly IFoodSuggestionService _service;

        public FoodSuggestionsController(IFoodSuggestionService service) => _service = service;

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateFoodSuggestionDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.CreateAsync(userId, dto);

            return Ok("Предлог је послат на разматрање!");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] SuggestionStatus? status)
            => Ok(await _service.GetAllAsync(status));

        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            await _service.ApproveAsync(id);

            return Ok("Предлог је одобрен и намирница је креирана!");
        }

        [HttpPost("{id}/reject")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject(int id, [FromBody] ApproveSuggestionDto dto)
        {
            await _service.RejectAsync(id, dto.AdminNote);

            return Ok("Предлог је одбијен!");
        }
    }
}
