using TaskGear.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TaskGear.Infrastructure.Config;

public class ProjectTaskConfig : IEntityTypeConfiguration<ProjectTask> 
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder) 
    {
        builder.HasKey(t => t.Id);
        builder.ToTable("tasks");

        builder.Property(t => t.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(t => t.Description)
            .HasMaxLength(600)
            .IsRequired();

        builder.HasOne(t => t.Project)
            .WithMany()
            .HasForeignKey(t => t.ProjectId);

        builder.HasOne(t => t.CreatedByMember)
            .WithMany()
            .HasForeignKey(t => t.CreatedBy);

        builder.HasOne(t => t.TaskState)
            .WithMany()
            .HasForeignKey(t => t.TaskStateId);
        
        builder.HasMany<Comment>()
            .WithOne(c => c.Task)
            .HasForeignKey(c => c.TaskId);
        
        builder.HasMany<ConnectedTask>()
            .WithOne(ct => ct.Task)
            .HasForeignKey(ct => ct.TaskId);

        builder.HasMany<Assignee>()
            .WithOne(a => a.Task)
            .HasForeignKey(a => a.TaskId);
    }
}