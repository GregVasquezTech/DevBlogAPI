namespace DevBlog.API.Models.Domain.Request
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public bool Active {  get; set; }
    }
}
