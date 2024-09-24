using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class BlogPostAdminEditModel
{
    public Guid Id { get; set; }

    public ApplicationUser? Author { get; set; }
    public Category? Category { get; set; }
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static BlogPostAdminEditModel FromBlogPostAdminDto(BlogPostAdminDto blogPostAdminDto)
    {
        if (blogPostAdminDto == null)
        {
            return new BlogPostAdminEditModel();
        }

        return new BlogPostAdminEditModel
        {
            Id = blogPostAdminDto.Id,

            Author = blogPostAdminDto.Author,
            Category = blogPostAdminDto.Category,
            // DtoToModelPropertyPlaceholder
            // Title = blogPostAdminDto.Title,
            // ToDoList = blogPostAdminDto.ToDoList,
        };
    }

    public static BlogPostAdminDto ToBlogPostAdminDto(BlogPostAdminEditModel blogPostAdminEditModel)
    {
        if (blogPostAdminEditModel == null)
        {
            return new BlogPostAdminDto();
        }

        return new BlogPostAdminDto
        {
            Id = blogPostAdminEditModel.Id,

            Author = blogPostAdminEditModel.Author,
            Category = blogPostAdminEditModel.Category,
            // ModelToDtoPropertyPlaceholder
            // Title = blogPostAdminEditModel.Title,
            // ToDoList = blogPostAdminEditModel.ToDoList,
        };
    }
}
