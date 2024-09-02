using Microsoft.AspNetCore.Identity;

namespace MyBlog.BusinessLogic.Entities;

public class ApplicationUserLogin : IdentityUserLogin<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
