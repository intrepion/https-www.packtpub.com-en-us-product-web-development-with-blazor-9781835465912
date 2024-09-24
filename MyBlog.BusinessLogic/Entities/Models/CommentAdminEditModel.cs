using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto commentAdminDto)
    {
        if (commentAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = commentAdminDto.Id,

            // DtoToModelPropertyPlaceholder
            // Title = commentAdminDto.Title,
            // ToDoList = commentAdminDto.ToDoList,
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel commentAdminEditModel)
    {
        if (commentAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = commentAdminEditModel.Id,

            // ModelToDtoPropertyPlaceholder
            // Title = commentAdminEditModel.Title,
            // ToDoList = commentAdminEditModel.ToDoList,
        };
    }
}
