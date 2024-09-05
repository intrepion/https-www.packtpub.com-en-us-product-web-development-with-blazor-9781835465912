﻿using ApplicationNamePlaceholder.BusinessLogic.Services;
using ApplicationNamePlaceholder.BusinessLogic.Services.Client;
using ApplicationNamePlaceholder.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

builder.Services.AddScoped<IAdminApplicationRoleService, ClientAdminApplicationRoleService>();
builder.Services.AddScoped<IAdminApplicationUserService, ClientAdminApplicationUserService>();

builder.Services.AddScoped<IBlogPostAdminService, BlogPostClientAdminService>();
// RegisterClientServiceCodePlaceholder

await builder.Build().RunAsync();
