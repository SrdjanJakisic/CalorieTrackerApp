using CalorieTracker.Application.DTO.FoodItem;
using CalorieTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/foods")]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodItemService _service;
        private readonly IWebHostEnvironment _env;

        public FoodsController(IFoodItemService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] int? categoryId,
            [FromQuery] bool? lenten, [FromQuery] bool? isApproved)
            => Ok(await _service.GetAllAsync(search, categoryId, lenten, isApproved));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateFoodItemDto dto)
        {
            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateFoodItemDto dto) 
            => Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/image")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            // 0) намирница мора да постоји пре било чега
            await _service.GetByIdAsync(id);

            // 1) валидација: фајл уопште послат?
            if (file == null || file.Length == 0) throw new ArgumentException("Фајл није послат!");

            // 2) валидација екстензије
            var allowed = new[] { ".jpg", ".jpeg", ".png" };
            var ext = Path.GetExtension(file.FileName).ToLower();
            if (!allowed.Contains(ext)) throw new ArgumentException("Дозвољени формати: jpg, jpeg, png!");

            // 3) валидација величине (макс 5MB)
            if (file.Length > 5 * 1024 * 1024) throw new ArgumentException("Максимална величина је 5MB!");

            // 4) направи фолдер ако не постоји
            var dir = Path.Combine(_env.WebRootPath, "images", "foods");
            Directory.CreateDirectory(dir);

            // 5) јединствено име фајла
            var fileName = $"{Guid.NewGuid()}{ext}";
            var fullPath = Path.Combine(dir, fileName);

            // 6) сачувај фајл на диск
            using (var stream = new FileStream(fullPath, FileMode.Create)) await file.CopyToAsync(stream);

            // 7) реалтивни URL који иде у базу и клијенту
            var url = $"/images/foods/{fileName}";

            // 8) упиши URL у базу преко сервиса
            await _service.SetImageUrlAsync(id, url);

            return Ok(new { imageUrl = url });
        }
    }
}
