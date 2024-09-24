using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlog.BusinessLogic.Services;
using MyBlog.BusinessLogic.Services.Client;
using MyBlog.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});
builder.Services.AddScoped<IApplicationRoleAdminService, ApplicationRoleClientAdminService>();
builder.Services.AddScoped<IApplicationUserAdminService, ApplicationUserClientAdminService>();

builder.Services.AddScoped<IBlogPostAdminService, BlogPostClientAdminService>();
builder.Services.AddScoped<IBlogPostTagAdminService, BlogPostTagClientAdminService>();
builder.Services.AddScoped<ICategoryAdminService, CategoryClientAdminService>();
builder.Services.AddScoped<ICommentAdminService, CommentClientAdminService>();
builder.Services.AddScoped<ITagAdminService, TagClientAdminService>();
// RegisterClientServiceCodePlaceholder

await builder.Build().RunAsync();
