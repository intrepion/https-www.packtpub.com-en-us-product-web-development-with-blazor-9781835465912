using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyBlog.BusinessLogic.Entities.Configuration;

public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments", x => x.IsTemporal());

        builder.Property(x => x.Text)
            .IsRequired();

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedComments)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.BlogPost)
            .WithMany(x => x.Comments)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Commenter)
            .WithMany(x => x.CommentedComments)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
