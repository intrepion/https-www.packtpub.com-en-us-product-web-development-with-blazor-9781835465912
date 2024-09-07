using Microsoft.AspNetCore.Identity;

namespace MyBlog.BusinessLogic.Entities;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
