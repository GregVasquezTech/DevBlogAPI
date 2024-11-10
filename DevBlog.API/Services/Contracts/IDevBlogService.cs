using DevBlog.API.Models.Domain;
using DevBlog.API.Models.Domain.Request;

namespace DevBlog.API.Services.Contracts
{
    public interface IDevBlogService
    {
        public Task<List<Category>?> GetCategories();
        public Task<Category> GetCategoryById(int categoryId);
        public Task<Category> CreateCategory(CategoryRequest categoryRequest);
        public System.Threading.Tasks.Task UpdateCategory(int categoryId, UpdateCategoryRequest updateCategoryRequest);
        public System.Threading.Tasks.Task DeleteCategory(int categoryId);
    }
}
