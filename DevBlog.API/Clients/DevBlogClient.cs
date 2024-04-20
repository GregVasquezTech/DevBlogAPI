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

        async Task<Category> IDevBlogClient.CreateCategory(CategoryRequest categoryRequest)
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

        async Task<Category> IDevBlogClient.DeleteCategory(Guid id)
        {
            var record = await _applicationDbContext.Categories.FirstOrDefaultAsync(d => d.Id == id);

            return record;
        }

        async Task<List<Category>> IDevBlogClient.GetCategories()
        {
            var records = await _applicationDbContext.Categories.ToListAsync();

            return records;
        }

        async Task<Category> IDevBlogClient.GetCategory(Guid id)
        {
            var record = await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            return record;
        }

        async Task<Category> IDevBlogClient.UpdateCategory(Guid id)
        {
            var serviceDevBlog = await _applicationDbContext.Categories.FirstOrDefaultAsync(u => u.Id == id);

            await _applicationDbContext.SaveChangesAsync();

            return serviceDevBlog;
        }
    }
}
