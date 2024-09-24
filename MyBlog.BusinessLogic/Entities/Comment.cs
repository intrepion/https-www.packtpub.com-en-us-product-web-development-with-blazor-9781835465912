namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Comment
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public BlogPost? BlogPost { get; set; }
    // ActualPropertyPlaceholder
}
