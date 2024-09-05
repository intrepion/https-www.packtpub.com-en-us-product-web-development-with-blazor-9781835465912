namespace MyBlog.BusinessLogic.Entities;

public class BlogPost
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    // public string PropertyNamePlaceholder { get; set; } = string.Empty;
}
