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
            var records = await _applicationDbContext.Categories.Where(x => x.IsDeleted != true).ToListAsync();

            return records;
        }

        public async Task<Category> GetCategory(string name)
        {
            var record = await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Name == name && x.IsDeleted == false);
            if (record == null)
            {
                return null;
            }
            return record;
        }

        public async Task<Category> CreateCategory(CategoryRequest categoryRequest)
        {
            var request = new Category()
            {
                Name = categoryRequest.Name,
                UrlHandle = categoryRequest.UrlHandle,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            await _applicationDbContext.Categories.AddAsync(request);
            await _applicationDbContext.SaveChangesAsync();

            return request;
        }

        public void DeleteCategory(string name)
        {
            var deleteRecord = GetCategory(name);
            if (deleteRecord != null)
            {
                _applicationDbContext.Remove(deleteRecord);
                _applicationDbContext.SaveChanges();
            }
        }

        public async Task<Category> UpdateCategory(string name)
        {
            var updateRecord = await GetCategory(name);
            if (updateRecord != null)
            {
                _applicationDbContext.Update(updateRecord);
                await _applicationDbContext.SaveChangesAsync();
            }

            return updateRecord;
        }
    }
}
