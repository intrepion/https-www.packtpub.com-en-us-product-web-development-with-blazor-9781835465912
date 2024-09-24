using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto blogPostAdminDto)
    {
        if (blogPostAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = blogPostAdminDto.Id,

            // DtoToModelPropertyPlaceholder
            // Title = blogPostAdminDto.Title,
            // ToDoList = blogPostAdminDto.ToDoList,
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel blogPostAdminEditModel)
    {
        if (blogPostAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = blogPostAdminEditModel.Id,

            // ModelToDtoPropertyPlaceholder
            // Title = blogPostAdminEditModel.Title,
            // ToDoList = blogPostAdminEditModel.ToDoList,
        };
    }
}
