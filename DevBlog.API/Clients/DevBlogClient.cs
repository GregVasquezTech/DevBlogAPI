using DevBlog.API.Clients.Contracts;
using DevBlog.API.Data;
using DevBlog.API.Models.Domain;
using DevBlog.API.Models.Domain.Request;
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

        public async Task<List<Category>> GetCategories()
        {
            var records = await _applicationDbContext.Categories.ToListAsync();

            return records;
        }

        public async Task<Category> GetCategory(Guid id)
        {
            var record = await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            return record;
        }

        public async Task<Category> CreateCategory(CategoryRequest categoryRequest)
        {
            var request = new Category()
            {
                Name = categoryRequest.Name,
                UrlHandle = categoryRequest.UrlHandle,
            };

            await _applicationDbContext.Categories.AddAsync(request);
            await _applicationDbContext.SaveChangesAsync();

            return request;
        }

        public async Task<Category> DeleteCategory(Guid id)
        {
            var record = await GetCategory(id);

            await _applicationDbContext.SaveChangesAsync();

            return record;
        }

        public async Task<Category> UpdateCategory(Guid id)
        {
            var serviceDevBlog = await GetCategory(id);

            await _applicationDbContext.SaveChangesAsync();

            return serviceDevBlog;
        }
    }
}
