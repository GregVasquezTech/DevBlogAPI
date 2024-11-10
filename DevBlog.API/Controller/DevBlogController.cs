using DevBlog.API.Models.Domain.Request;
using DevBlog.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.API.Controllers
{
    // https://localhost:XXXX/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class DevBlogController : ControllerBase
    {
        private readonly IDevBlogService _devBlogService;

        public DevBlogController(IDevBlogService devBlogService)
        {
            _devBlogService = devBlogService;
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetGategories()
        {
            return Ok(await _devBlogService.GetCategories());
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            return Ok(await _devBlogService.GetCategoryById(categoryId));
        }

        /// <summary>
        /// Create a Category
        /// </summary>
        /// <param name="categoryRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateCategory(CategoryRequest categoryRequest)
        {
            return Ok(await _devBlogService.CreateCategory(categoryRequest));
        }

        /// <summary>
        /// Update a Category
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, UpdateCategoryRequest updateCategoryRequest)
        {
            await _devBlogService.UpdateCategory(categoryId, updateCategoryRequest);
            return NoContent();
        }

        /// <summary>
        /// Delete a Category
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("{categoryId}")]
        public ActionResult DeleteCategory(int categoryId)
        {
            _devBlogService.DeleteCategory(categoryId);
            return NoContent();
        }
    }
}