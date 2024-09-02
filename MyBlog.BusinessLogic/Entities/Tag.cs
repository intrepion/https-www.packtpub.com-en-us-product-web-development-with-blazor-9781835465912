namespace MyBlog.BusinessLogic.Entities;

public class Tag
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public ICollection<BlogPostTag> BlogPostTags { get; set; } = [];
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
