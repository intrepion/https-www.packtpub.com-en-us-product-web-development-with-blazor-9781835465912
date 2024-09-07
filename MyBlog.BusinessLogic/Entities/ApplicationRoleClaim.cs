using Microsoft.AspNetCore.Identity;

namespace MyBlog.BusinessLogic.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
