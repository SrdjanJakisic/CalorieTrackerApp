using CalorieTracker.Application.DTO.FoodCategory;
using CalorieTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/categories")]
    public class FoodCategoriesController : ControllerBase
    {
        private readonly IFoodCategoryService _service;
        public FoodCategoriesController(IFoodCategoryService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateFoodCategoryDto dto)
        {
            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateFoodCategoryDto dto) 
            => Ok(await _service.UpdateAsync(id, dto)); 
    }
}
