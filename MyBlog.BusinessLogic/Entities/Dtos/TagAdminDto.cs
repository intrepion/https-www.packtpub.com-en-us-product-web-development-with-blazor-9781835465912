namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class TagAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public List<BlogPostTag>? BlogPostTags { get; set; } = [];
    public string Name { get; set; } = string.Empty;
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static TagAdminDto FromTag(Tag? tag)
    {
        if (tag == null)
        {
            return new TagAdminDto();
        }

        return new TagAdminDto
        {
            Id = tag.Id,

            Name = tag.Name,
            // EntityToDtoPropertyPlaceholder
            // Title = tag.Title,
            // ToDoList = tag.ToDoList,
        };
    }

    public static Tag ToTag(ApplicationUser applicationUser, TagAdminDto tagAdminDto)
    {
        return new Tag
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = tagAdminDto.Id,

            Name = tagAdminDto.Name,
            // DtoToEntityPropertyPlaceholder
            // Title = tagAdminDto.Title,
            // ToDoList = tagAdminDto.ToDoList,
        };
    }
}
