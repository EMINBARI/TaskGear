using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGear.Core.Models;

namespace TaskGear.Infrastruckture.Config;

public class AssigneeConfig : IEntityTypeConfiguration<Assignee>
{
    public void Configure(EntityTypeBuilder<Assignee> builder)
    {
        builder.HasKey(a => a.Id);
        builder.ToTable("Assignees");

        builder.HasOne(a => a.Task)
            .WithMany()
            .HasForeignKey(a => a.TaskId);
        
        builder.HasOne(a => a.ProjectMember)
            .WithMany()
            .HasForeignKey(a => a.ProjectMemberId);
            
    }
}