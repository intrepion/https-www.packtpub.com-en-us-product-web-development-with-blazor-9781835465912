using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class CommentAdminEditModel
{
    public Guid Id { get; set; }

    public BlogPost? BlogPost { get; set; }
    public ApplicationUser? Commenter { get; set; }
    public DateTime Date { get; set; }
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
            // ModelToDtoPropertyPlaceholder
            // Title = commentAdminEditModel.Title,
            // ToDoList = commentAdminEditModel.ToDoList,
        };
    }
}
