namespace DevBlog.API.Models.Domain
{
    public class Category
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
