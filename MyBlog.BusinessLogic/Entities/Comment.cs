namespace MyBlog.BusinessLogic.Entities;

public class Comment
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public BlogPost? BlogPost { get; set; }
    public ApplicationUser? Commenter { get; set; }
    public DateTime Date { get; set; }
    public string Text { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
