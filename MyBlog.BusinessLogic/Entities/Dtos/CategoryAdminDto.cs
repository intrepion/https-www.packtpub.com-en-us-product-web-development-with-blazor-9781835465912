namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? category)
    {
        if (category == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = category.Id,

            // EntityToDtoPropertyPlaceholder
            // Title = category.Title,
            // ToDoList = category.ToDoList,
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser applicationUser, EntityNamePlaceholderAdminDto categoryAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = categoryAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
            // Title = categoryAdminDto.Title,
            // ToDoList = categoryAdminDto.ToDoList,
        };
    }
}
