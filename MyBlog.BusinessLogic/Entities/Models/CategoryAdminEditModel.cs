using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto categoryAdminDto)
    {
        if (categoryAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = categoryAdminDto.Id,

            // DtoToModelPropertyPlaceholder
            // Title = categoryAdminDto.Title,
            // ToDoList = categoryAdminDto.ToDoList,
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel categoryAdminEditModel)
    {
        if (categoryAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = categoryAdminEditModel.Id,

            // ModelToDtoPropertyPlaceholder
            // Title = categoryAdminEditModel.Title,
            // ToDoList = categoryAdminEditModel.ToDoList,
        };
    }
}
