using AutoMapper;
using DevBlog.API.Models.Domain;
using DevBlog.API.Models.Domain.Request;

namespace DevBlog.API.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryRequest, Category>();

            CreateMap<UpdateCategoryRequest, Category>();
        }
    }
}
