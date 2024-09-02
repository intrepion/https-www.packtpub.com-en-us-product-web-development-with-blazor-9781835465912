using Microsoft.AspNetCore.Identity;

namespace MyBlog.BusinessLogic.Entities;

public class ApplicationUserToken : IdentityUserToken<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
