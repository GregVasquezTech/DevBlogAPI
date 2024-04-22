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
            var result = await _devBlogService.GetCategories();
            return Ok(result);
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var result = await _devBlogService.GetCategory(id);
            return Ok(result);
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
            var result = await _devBlogService.CreateCategory(categoryRequest);

            return Ok(result);
        }
      
        /// <summary>
        /// Update a Category
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id)
        {
            var result = await _devBlogService.UpdateCategory(id);
            return Ok(result);
        }
        
        /// <summary>
        /// Delete a Category
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _devBlogService.DeleteCategory(id);
            return Ok(result);
        }
    }
}
