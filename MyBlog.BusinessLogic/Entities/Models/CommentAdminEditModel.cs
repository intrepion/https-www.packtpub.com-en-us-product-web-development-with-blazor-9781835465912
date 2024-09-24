using MyBlog.BusinessLogic.Entities.Dtos;

namespace MyBlog.BusinessLogic.Entities.Models;

public class CommentAdminEditModel
{
    public Guid Id { get; set; }

    public BlogPost? BlogPost { get; set; }
    public ApplicationUser? Commenter { get; set; }
    public DateTime Date { get; set; }
    public string Text { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static CommentAdminEditModel FromCommentAdminDto(CommentAdminDto commentAdminDto)
    {
        if (commentAdminDto == null)
        {
            return new CommentAdminEditModel();
        }

        return new CommentAdminEditModel
        {
            Id = commentAdminDto.Id,

            BlogPost = commentAdminDto.BlogPost,
            Commenter = commentAdminDto.Commenter,
            Date = commentAdminDto.Date,
            Text = commentAdminDto.Text,
            // DtoToModelPropertyPlaceholder
            // Title = commentAdminDto.Title,
            // ToDoList = commentAdminDto.ToDoList,
        };
    }

    public static CommentAdminDto ToCommentAdminDto(CommentAdminEditModel commentAdminEditModel)
    {
        if (commentAdminEditModel == null)
        {
            return new CommentAdminDto();
        }

        return new CommentAdminDto
        {
            Id = commentAdminEditModel.Id,

            BlogPost = commentAdminEditModel.BlogPost,
            Commenter = commentAdminEditModel.Commenter,
            Date = commentAdminEditModel.Date,
            Text = commentAdminEditModel.Text,
            // ModelToDtoPropertyPlaceholder
            // Title = commentAdminEditModel.Title,
            // ToDoList = commentAdminEditModel.ToDoList,
        };
    }
}
