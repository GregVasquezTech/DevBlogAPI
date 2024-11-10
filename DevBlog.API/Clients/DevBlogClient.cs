using DevBlog.API.Clients.Contracts;
using DevBlog.API.Data;
using DevBlog.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.API.Clients
{
    public class DevBlogClient : IDevBlogClient
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DevBlogClient(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<Category>?> GetCategories(bool? active)
        {
            if (active != null)
            {
                return await _applicationDbContext.Categories.Where(c => c.Active == active).ToListAsync();
            } else {
                return await _applicationDbContext.Categories.ToListAsync();
            }
        }
        public async Task<Category> GetCategoryById(int categoryId, bool? active)
        {
            if (active != null)
            {
                return await _applicationDbContext.Categories.FirstAsync(c => c.CategoryId == categoryId && c.Active == active);
            } else
            {
                return await _applicationDbContext.Categories.FirstAsync(c => c.CategoryId == categoryId);
            }
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await _applicationDbContext.Categories.AddAsync(category);
            await _applicationDbContext.SaveChangesAsync();

            return category;
        }
        public async System.Threading.Tasks.Task UpdateCategory(int categoryId, Category category)
        {
            if (await GetCategoryById(categoryId, category.Active) == null)
            {
                throw new Exception($"Did not find category: {category}");
            }
            _applicationDbContext.Update(category);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task DeleteCategory(int categoryId)
        {
            Category record = await GetCategoryById(categoryId, null);
            if (record == null)
            {
                throw new Exception($"Did not find category for {categoryId}");
            }
            _applicationDbContext.Remove(record);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
