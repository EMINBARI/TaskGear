using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGear.Core.Models;

namespace TaskGear.Infrastructure.Config;

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);
        builder.ToTable("projects");

        builder.Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(p => p.Description)
            .HasMaxLength(600)
            .IsRequired();

        builder.HasMany<ProjectTask>()
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId);
        
        builder.HasMany<ProjectMember>()
            .WithOne(pm => pm.Project)
            .HasForeignKey(pm => pm.ProjectId);
    }
}