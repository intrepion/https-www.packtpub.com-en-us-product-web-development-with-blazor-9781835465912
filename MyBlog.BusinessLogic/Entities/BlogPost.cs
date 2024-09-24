namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class BlogPost
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ApplicationUser? Author { get; set; }
    public List<BlogPostTag>? BlogPostTags { get; set; } = [];
    // ActualPropertyPlaceholder
}
