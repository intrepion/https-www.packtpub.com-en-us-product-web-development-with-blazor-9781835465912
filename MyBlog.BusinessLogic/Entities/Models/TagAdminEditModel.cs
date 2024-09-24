using MyBlog.BusinessLogic.Entities.Dtos;

namespace MyBlog.BusinessLogic.Entities.Models;

public class TagAdminEditModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static TagAdminEditModel FromTagAdminDto(TagAdminDto tagAdminDto)
    {
        if (tagAdminDto == null)
        {
            return new TagAdminEditModel();
        }

        return new TagAdminEditModel
        {
            Id = tagAdminDto.Id,

            Name = tagAdminDto.Name,
            // DtoToModelPropertyPlaceholder
            // Title = tagAdminDto.Title,
            // ToDoList = tagAdminDto.ToDoList,
        };
    }

    public static TagAdminDto ToTagAdminDto(TagAdminEditModel tagAdminEditModel)
    {
        if (tagAdminEditModel == null)
        {
            return new TagAdminDto();
        }

        return new TagAdminDto
        {
            Id = tagAdminEditModel.Id,

            Name = tagAdminEditModel.Name,
            // ModelToDtoPropertyPlaceholder
            // Title = tagAdminEditModel.Title,
            // ToDoList = tagAdminEditModel.ToDoList,
        };
    }
}
