namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? blogPostTag)
    {
        if (blogPostTag == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = blogPostTag.Id,

            // EntityToDtoPropertyPlaceholder
            // Title = blogPostTag.Title,
            // ToDoList = blogPostTag.ToDoList,
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser applicationUser, EntityNamePlaceholderAdminDto blogPostTagAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = blogPostTagAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
            // Title = blogPostTagAdminDto.Title,
            // ToDoList = blogPostTagAdminDto.ToDoList,
        };
    }
}
