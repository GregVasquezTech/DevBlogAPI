using DevBlog.API.Models.Domain;
using DevBlog.API.Models.Domain.Request;

namespace DevBlog.API.Services.Contracts
{
    public interface IDevBlogService
    {
        public Task<List<Category>> GetCategories();
        public Task<Category> GetCategory(Guid id);
        public Task<Category> CreateCategory(CategoryRequest categoryRequest);
        public Task<Category> UpdateCategory(Guid id);
        public Task<Category> DeleteCategory(Guid id);
    }
}
