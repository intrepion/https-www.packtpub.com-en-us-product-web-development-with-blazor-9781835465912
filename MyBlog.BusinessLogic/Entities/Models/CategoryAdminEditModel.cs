using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class CategoryAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static CategoryAdminEditModel FromCategoryAdminDto(CategoryAdminDto categoryAdminDto)
    {
        if (categoryAdminDto == null)
        {
            return new CategoryAdminEditModel();
        }

        return new CategoryAdminEditModel
        {
            Id = categoryAdminDto.Id,

            Name = categoryAdminDto.Name,
            // DtoToModelPropertyPlaceholder
            // Title = categoryAdminDto.Title,
            // ToDoList = categoryAdminDto.ToDoList,
        };
    }

    public static CategoryAdminDto ToCategoryAdminDto(CategoryAdminEditModel categoryAdminEditModel)
    {
        if (categoryAdminEditModel == null)
        {
            return new CategoryAdminDto();
        }

        return new CategoryAdminDto
        {
            Id = categoryAdminEditModel.Id,

            Name = categoryAdminEditModel.Name,
            // ModelToDtoPropertyPlaceholder
            // Title = categoryAdminEditModel.Title,
            // ToDoList = categoryAdminEditModel.ToDoList,
        };
    }
}
