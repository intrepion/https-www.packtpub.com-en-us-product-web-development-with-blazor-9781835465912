namespace MyBlog.BusinessLogic.Entities.Dtos;

public class BlogPostTagAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public BlogPost? BlogPost { get; set; }
    public Tag? Tag { get; set; }
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static BlogPostTagAdminDto FromBlogPostTag(BlogPostTag? blogPostTag)
    {
        if (blogPostTag == null)
        {
            return new BlogPostTagAdminDto();
        }

        return new BlogPostTagAdminDto
        {
            Id = blogPostTag.Id,

            BlogPost = blogPostTag.BlogPost,
            Tag = blogPostTag.Tag,
            // EntityToDtoPropertyPlaceholder
            // Title = blogPostTag.Title,
            // ToDoList = blogPostTag.ToDoList,
        };
    }

    public static BlogPostTag ToBlogPostTag(ApplicationUser applicationUser, BlogPostTagAdminDto blogPostTagAdminDto)
    {
        return new BlogPostTag
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = blogPostTagAdminDto.Id,

            BlogPost = blogPostTagAdminDto.BlogPost,
            Tag = blogPostTagAdminDto.Tag,
            // DtoToEntityPropertyPlaceholder
            // Title = blogPostTagAdminDto.Title,
            // ToDoList = blogPostTagAdminDto.ToDoList,
        };
    }
}
