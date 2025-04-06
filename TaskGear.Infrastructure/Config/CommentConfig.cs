using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGear.Core.Models;

namespace TaskGear.Infrastructure.Config;

public class CommentConfig : IEntityTypeConfiguration<Comment> 
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Content)
            .HasMaxLength(600)
            .IsRequired();
        
        builder.HasOne(c => c.CreatedByMember)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy);

        builder.HasOne(c => c.Task)
            .WithMany()
            .HasForeignKey(c => c.TaskId);
    }
}