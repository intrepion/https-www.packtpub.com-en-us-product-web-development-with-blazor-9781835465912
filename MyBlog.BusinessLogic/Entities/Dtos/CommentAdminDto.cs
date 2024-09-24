namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class CommentAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public BlogPost? BlogPost { get; set; }
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static CommentAdminDto FromComment(Comment? comment)
    {
        if (comment == null)
        {
            return new CommentAdminDto();
        }

        return new CommentAdminDto
        {
            Id = comment.Id,

            BlogPost = comment.BlogPost,
            // EntityToDtoPropertyPlaceholder
            // Title = comment.Title,
            // ToDoList = comment.ToDoList,
        };
    }

    public static Comment ToComment(ApplicationUser applicationUser, CommentAdminDto commentAdminDto)
    {
        return new Comment
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = commentAdminDto.Id,

            BlogPost = commentAdminDto.BlogPost,
            // DtoToEntityPropertyPlaceholder
            // Title = commentAdminDto.Title,
            // ToDoList = commentAdminDto.ToDoList,
        };
    }
}
