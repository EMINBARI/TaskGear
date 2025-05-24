using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGear.Core.Models;

namespace TaskGear.Infrastructure.Config;

public class ConnectedTaskConfig : IEntityTypeConfiguration<ConnectedTask>
{
    public void Configure(EntityTypeBuilder<ConnectedTask> builder)
    {
        builder.HasKey
        (
            ct => new {ct.Id, ct.SourceTaskId, ct.TargetTaskId}
        );
        builder.ToTable("connected_tasks");

        builder.HasOne(ct => ct.SourceTask)
            .WithMany()
            .HasForeignKey(ct => ct.SourceTaskId)
            .OnDelete(DeleteBehavior.Cascade);   
        
        builder.HasOne(ct => ct.TargetTask)
            .WithMany()
            .HasForeignKey(ct => ct.TargetTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        // builder.HasOne(ct => ct.Task)
        //     .WithMany()
        //     .HasForeignKey(ct => ct.TaskId);   
    }
}