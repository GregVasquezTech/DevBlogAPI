using AutoMapper;
using DevBlog.API.Clients.Contracts;
using DevBlog.API.Models.Domain;
using DevBlog.API.Models.Domain.Request;
using DevBlog.API.Services.Contracts;

namespace DevBlog.API.Services
{
    public class DevBlogService : IDevBlogService
    {
        private readonly IDevBlogClient _devBlogClient;
        private readonly IMapper _mapper;

        public DevBlogService(IDevBlogClient devBlogClient, IMapper mapper)
        {
            _devBlogClient = devBlogClient;
            _mapper = mapper;
        }

        public async Task<List<Category>?> GetCategories()
        {
            return await _devBlogClient.GetCategories(null);
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _devBlogClient.GetCategoryById(categoryId, null);
        }

        public async Task<Category> CreateCategory(CategoryRequest categoryRequest)
        {
            try
            {
                return await _devBlogClient.CreateCategory(_mapper.Map<Category>(categoryRequest));
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating category", ex);
            }
        }
        public async System.Threading.Tasks.Task UpdateCategory(int categoryId, UpdateCategoryRequest updateCategoryRequest)
        {
            Category category = _mapper.Map<Category>(updateCategoryRequest);
            await _devBlogClient.UpdateCategory(categoryId, category);
        }
        public async System.Threading.Tasks.Task DeleteCategory(int categoryId)
        {
            await _devBlogClient.DeleteCategory(categoryId);
        }
    }
}
