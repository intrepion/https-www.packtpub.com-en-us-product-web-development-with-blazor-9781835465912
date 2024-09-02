﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyBlog.BusinessLogic.Entities.Configuration;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", x => x.IsTemporal());

        builder.Property(x => x.Name)
            .IsRequired();

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedCategories)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
