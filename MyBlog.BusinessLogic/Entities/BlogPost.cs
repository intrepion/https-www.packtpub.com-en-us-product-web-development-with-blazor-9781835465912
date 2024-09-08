namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class BlogPost
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public ApplicationUser? Author { get; set; }
    public List<BlogPostTag>? BlogPostTags { get; set; } = [];
    public Category? Category { get; set; }
    public List<Comment>? Comments { get; set; } = [];
    public DateTime PublishDate { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
