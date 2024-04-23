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

        public async Task<List<Category>?> GetCategories()
        {
            var serviceDevBlog = await _devBlogClient.GetCategories();

            var categories = new List<Category>();

            foreach(var category in serviceDevBlog)
            {
                categories.Add(category);
            }
            return categories;
        }

        public async Task<Category> GetCategory(string name)
        {
            var serviceDevBlog = await _devBlogClient.GetCategory(name);

            var response = new Category() 
            { 
                Id = serviceDevBlog.Id, 
                Name = serviceDevBlog.Name,
                UrlHandle = serviceDevBlog.UrlHandle,
            };

            return response;
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

        public async Task<Category> DeleteCategory(string name)
        {
            var serviceDevBlog = await _devBlogClient.DeleteCategory(name);

            return (Category) serviceDevBlog;
        }

        public async Task<Category> UpdateCategory(string name)
        {
            var serviceDevBlog = await _devBlogClient.UpdateCategory(name);

            return (Category) serviceDevBlog;
        }
    }
}
