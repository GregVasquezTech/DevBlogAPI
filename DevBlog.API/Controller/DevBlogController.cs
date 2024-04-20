using DevBlog.API.Models.Domain;
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

/*        // Get all objects
        [HttpGet]
        public async Task<IActionResult> GetGategories();
        // Get object by {id}
        [HttpGet]
        public async Task<IActionResult> GetCategory();*/

        /// <summary>
        /// Create a Category
        /// </summary>
        /// <param name="categoryRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequest categoryRequest)
        {
            var result = await _devBlogService.CreateCategory(categoryRequest);

            return Ok(result);
        }
/*        // Update object by {id}
        [HttpPut]
        public async Task<IActionResult> UpdateCategory();
        // Delete object by {id}
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory();*/
    }
}
