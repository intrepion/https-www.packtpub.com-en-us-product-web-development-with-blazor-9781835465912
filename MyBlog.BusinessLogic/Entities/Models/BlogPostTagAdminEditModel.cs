using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class BlogPostTagAdminEditModel
{
    public Guid Id { get; set; }

    public BlogPost? BlogPost { get; set; }
    public Tag? Tag { get; set; }
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static BlogPostTagAdminEditModel FromBlogPostTagAdminDto(BlogPostTagAdminDto blogPostTagAdminDto)
    {
        if (blogPostTagAdminDto == null)
        {
            return new BlogPostTagAdminEditModel();
        }

        return new BlogPostTagAdminEditModel
        {
            Id = blogPostTagAdminDto.Id,

            BlogPost = blogPostTagAdminDto.BlogPost,
            Tag = blogPostTagAdminDto.Tag,
            // DtoToModelPropertyPlaceholder
            // Title = blogPostTagAdminDto.Title,
            // ToDoList = blogPostTagAdminDto.ToDoList,
        };
    }

    public static BlogPostTagAdminDto ToBlogPostTagAdminDto(BlogPostTagAdminEditModel blogPostTagAdminEditModel)
    {
        if (blogPostTagAdminEditModel == null)
        {
            return new BlogPostTagAdminDto();
        }

        return new BlogPostTagAdminDto
        {
            Id = blogPostTagAdminEditModel.Id,

            BlogPost = blogPostTagAdminEditModel.BlogPost,
            Tag = blogPostTagAdminEditModel.Tag,
            // ModelToDtoPropertyPlaceholder
            // Title = blogPostTagAdminEditModel.Title,
            // ToDoList = blogPostTagAdminEditModel.ToDoList,
        };
    }
}
