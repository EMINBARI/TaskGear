using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGear.Core.Models;

namespace TaskGear.Infrastructure.Config;

public class TaskStateConfig : IEntityTypeConfiguration<TaskState>
{
    public void Configure(EntityTypeBuilder<TaskState> builder)
    {
        builder.HasKey(ts => ts.Id);
        builder.ToTable("task_states");

        builder.Property(ts => ts.Name)
            .HasMaxLength(80)
            .IsRequired();
        
        builder.HasMany<ProjectTask>()
            .WithOne(t => t.TaskState)
            .HasForeignKey(t => t.TaskStateId);
    }
}