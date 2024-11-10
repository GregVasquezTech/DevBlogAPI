using System.Text.Json.Serialization;

namespace DevBlog.API.Models.Domain.Request
{
    public class CategoryRequest
    {
        [JsonIgnore]
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
