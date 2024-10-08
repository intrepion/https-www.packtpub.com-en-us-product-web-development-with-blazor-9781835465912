﻿namespace MyBlog.BusinessLogic.Entities;

public class Tag
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public List<BlogPostTag>? BlogPostTags { get; set; } = [];
    public string Name { get; set; } = string.Empty;
    public string NormalizedName { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
