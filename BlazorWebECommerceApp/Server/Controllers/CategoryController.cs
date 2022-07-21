using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebECommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetCategories()
        {
            var result = await _categoryService.GetCategories();
            return Ok(result);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAdminCategories()
        {
            var result = await _categoryService.GetAdminCategories();
            return Ok(result);
        }

        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            return Ok(result);
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> AddCategory(Category category)
        {
            var result = await _categoryService.AddCategory(category);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> UpdateCategory(Category category)
        {
            var result = await _categoryService.UpdateCategory(category);
            return Ok(result);
        }
    }
}
