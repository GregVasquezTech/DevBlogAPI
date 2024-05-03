using DevBlog.API.Models.Domain;
using DevBlog.API.Models.Domain.Request;

namespace DevBlog.API.Services.Contracts
{
    public interface IDevBlogService
    {
        public Task<List<Category>> GetCategories();
        public Task<Category> GetCategory(string name);
        public Task<Category> CreateCategory(CategoryRequest categoryRequest);
        public Task<Category> UpdateCategory(string name);
        public void DeleteCategory(string name);
    }
}
