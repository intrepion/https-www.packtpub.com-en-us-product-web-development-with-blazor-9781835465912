namespace MyBlog.BusinessLogic.Entities;

public class BlogPostTag
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public BlogPost? BlogPost { get; set; }
    public Tag? Tag { get; set; }
    // ActualPropertyPlaceholder
}
