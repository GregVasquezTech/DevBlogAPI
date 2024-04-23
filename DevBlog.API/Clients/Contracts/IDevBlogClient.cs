using DevBlog.API.Models.Domain;
using DevBlog.API.Models.Domain.Request;

namespace DevBlog.API.Clients.Contracts
{
    public interface IDevBlogClient
    {
        public Task<List<Category>?> GetCategories();
        public Task<Category> GetCategory(string name);
        public Task<Category> CreateCategory(CategoryRequest categoryRequest);
        public Task<Category> UpdateCategory(string name);
        public Task<Category> DeleteCategory(string name);
    }
}
