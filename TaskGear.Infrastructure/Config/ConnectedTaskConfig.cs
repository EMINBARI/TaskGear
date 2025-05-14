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
            ct => new {ct.Id, ct.TaskId1, ct.TaskId2}
        );
        builder.ToTable("connected_tasks");

        builder.HasOne(ct => ct.Task1)
            .WithMany()
            .HasForeignKey(ct => ct.TaskId1)
            .OnDelete(DeleteBehavior.Cascade);   
        
        builder.HasOne(ct => ct.Task2)
            .WithMany()
            .HasForeignKey(ct => ct.TaskId2)
            .OnDelete(DeleteBehavior.Cascade);

        // builder.HasOne(ct => ct.Task)
        //     .WithMany()
        //     .HasForeignKey(ct => ct.TaskId);   
    }
}