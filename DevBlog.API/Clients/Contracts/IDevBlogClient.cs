using DevBlog.API.Models.Domain;

namespace DevBlog.API.Clients.Contracts
{
    public interface IDevBlogClient
    {
        public Task<List<Category>?> GetCategories(bool? active);
        public Task<Category> GetCategoryById(int categoryId, bool? active);
        public Task<Category> CreateCategory(Category category);
        public System.Threading.Tasks.Task UpdateCategory(int categoryId, Category category);
        public System.Threading.Tasks.Task DeleteCategory(int categoryId);
    }
}
