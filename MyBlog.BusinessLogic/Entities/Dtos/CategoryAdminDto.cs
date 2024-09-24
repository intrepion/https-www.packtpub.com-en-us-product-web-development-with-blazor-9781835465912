namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class CategoryAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public List<BlogPost>? BlogPosts { get; set; } = [];
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static CategoryAdminDto FromCategory(Category? category)
    {
        if (category == null)
        {
            return new CategoryAdminDto();
        }

        return new CategoryAdminDto
        {
            Id = category.Id,

            // EntityToDtoPropertyPlaceholder
            // Title = category.Title,
            // ToDoList = category.ToDoList,
        };
    }

    public static Category ToCategory(ApplicationUser applicationUser, CategoryAdminDto categoryAdminDto)
    {
        return new Category
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = categoryAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
            // Title = categoryAdminDto.Title,
            // ToDoList = categoryAdminDto.ToDoList,
        };
    }
}
