using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGear.Core.Models;

namespace TaskGear.Infrastructure.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.ToTable("users");

        builder.Property(u => u.Name)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(u => u.Email)
            .IsRequired();

        builder.Property(u => u.ImageUrl)
            .IsRequired(false);
        
        builder.Property(u => u.PasswordHash)
            .IsRequired();

        
    }
}