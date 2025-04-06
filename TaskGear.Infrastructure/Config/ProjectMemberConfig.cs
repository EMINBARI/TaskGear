using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGear.Core.Models;

namespace TaskGear.Infrastructure.Config;

public class ProjectMemberConfig: IEntityTypeConfiguration<ProjectMember>
{
    public void Configure(EntityTypeBuilder<ProjectMember> builder) 
    {
        builder.HasKey(m => m.Id);
        builder.ToTable("project_members");

        builder.HasOne(m => m.User)
            .WithMany()
            .HasForeignKey(m => m.UserId);
        
        builder.HasOne(m => m.Project)
            .WithMany()
            .HasForeignKey(m => m.ProjectId);
        
        builder.HasMany<ProjectTask>()
            .WithOne(pt => pt.CreatedByMember)
            .HasForeignKey(pt => pt.CreatedBy);

        builder.HasMany<Assignee>()
            .WithOne(a => a.ProjectMember)
            .HasForeignKey(a => a.ProjectMemberId);
        
        builder.HasMany<Comment>()
            .WithOne(c => c.CreatedByMember)
            .HasForeignKey(c => c.CreatedBy);
    }
}