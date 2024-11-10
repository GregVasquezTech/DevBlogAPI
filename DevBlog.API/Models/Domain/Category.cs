namespace DevBlog.API.Models.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Active { get; set; }
    }
}
