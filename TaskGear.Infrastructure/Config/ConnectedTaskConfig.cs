using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGear.Core.Models;

namespace TaskGear.Infrastructure.Config;

public class ConnectedTaskConfig : IEntityTypeConfiguration<ConnectedTask>
{
    public void Configure(EntityTypeBuilder<ConnectedTask> builder)
    {
        builder.HasKey(ct => ct.Id);
        builder.ToTable("connected_tasks");

        builder.HasOne(ct => ct.Task)
            .WithMany()
            .HasForeignKey(ct => ct.TaskId);   
    }
}