using DevBlog.API.Clients;
using DevBlog.API.Clients.Contracts;
using DevBlog.API.Models.Domain;
using DevBlog.API.Models.Domain.Request;
using DevBlog.API.Services.Contracts;

namespace DevBlog.API.Services
{
    public class DevBlogService : IDevBlogService
    {
        private readonly IDevBlogClient _devBlogClient;

        public DevBlogService(IDevBlogClient devBlogClient)
        {
            _devBlogClient = devBlogClient;
        }

        public Task<List<Category>?> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> CreateCategory(CategoryRequest categoryRequest)
        {
            try
            {
                var serviceDevBlog = await _devBlogClient.CreateCategory(categoryRequest);

                var response = new Category
                {
                    Id = serviceDevBlog.Id,
                    Name = serviceDevBlog.Name,
                    UrlHandle = serviceDevBlog.UrlHandle,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating category", ex);
            }
        }

        public Task<Category> DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> EditCategory(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
