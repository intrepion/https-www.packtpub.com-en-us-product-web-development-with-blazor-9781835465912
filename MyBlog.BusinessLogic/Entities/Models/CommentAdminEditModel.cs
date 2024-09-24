using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class CommentAdminEditModel
{
    public Guid Id { get; set; }

    public BlogPost? BlogPost { get; set; }
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
            // ModelToDtoPropertyPlaceholder
            // Title = commentAdminEditModel.Title,
            // ToDoList = commentAdminEditModel.ToDoList,
        };
    }
}
