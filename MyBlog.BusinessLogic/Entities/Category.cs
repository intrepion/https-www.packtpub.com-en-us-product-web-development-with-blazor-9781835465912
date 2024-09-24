namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Category
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public List<BlogPost>? BlogPosts { get; set; } = [];
    // ActualPropertyPlaceholder
}
