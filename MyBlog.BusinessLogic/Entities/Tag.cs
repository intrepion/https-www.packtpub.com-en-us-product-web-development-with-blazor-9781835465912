﻿namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Tag
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public List<BlogPostTag>? BlogPostTags { get; set; } = [];
    // ActualPropertyPlaceholder
}
