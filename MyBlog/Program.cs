﻿using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlog.BusinessLogic.Data;
using MyBlog.BusinessLogic.Entities;
using MyBlog.BusinessLogic.Services;
using MyBlog.BusinessLogic.Services.Server;
using MyBlog.Client.Pages;
using MyBlog.Components;
using MyBlog.Components.Account;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

if (builder.Environment.EnvironmentName == "Test")
{
    builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
        options.UseSqlite(connectionString));
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!),
});

builder.Services.AddScoped<IApplicationRoleAdminService, ApplicationRoleAdminService>();
builder.Services.AddScoped<IApplicationUserAdminService, ApplicationUserAdminService>();

builder.Services.AddScoped<IBlogPostAdminService, BlogPostAdminService>();
builder.Services.AddScoped<IBlogPostTagAdminService, BlogPostTagAdminService>();
builder.Services.AddScoped<ICategoryAdminService, CategoryAdminService>();
builder.Services.AddScoped<ICommentAdminService, CommentAdminService>();
builder.Services.AddScoped<ITagAdminService, TagAdminService>();
// RegisterServerServiceCodePlaceholder

var app = builder.Build();

if (app.Environment.EnvironmentName == "Test")
{
    app.UseWebAssemblyDebugging();
    await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
    var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
    await DatabaseUtility.EnsureDbCreatedAndSeedAsync(options);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MyBlog.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
