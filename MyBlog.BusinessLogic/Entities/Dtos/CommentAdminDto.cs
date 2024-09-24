namespace MyBlog.BusinessLogic.Entities.Dtos;

public class CommentAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public BlogPost? BlogPost { get; set; }
    public ApplicationUser? Commenter { get; set; }
    public DateTime Date { get; set; }
    public string Text { get; set; } = string.Empty;
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
            Commenter = comment.Commenter,
            Date = comment.Date,
            Text = comment.Text,
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
            Commenter = commentAdminDto.Commenter,
            Date = commentAdminDto.Date,
            Text = commentAdminDto.Text,
            // DtoToEntityPropertyPlaceholder
            // Title = commentAdminDto.Title,
            // ToDoList = commentAdminDto.ToDoList,
        };
    }
}
