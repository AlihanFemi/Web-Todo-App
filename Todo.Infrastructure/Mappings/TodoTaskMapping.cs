﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Models;

namespace Todo.Infrastructure.Mappings
{
    internal class TodoTaskMapping : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.ToTable("todo_tasks", "dbo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(e => e.DueDate).HasColumnName("date").IsRequired();
            builder.Property(e => e.Description).HasColumnName("description").IsRequired();
            builder.Property(e => e.IsCompleted).HasColumnName("is_completed").HasDefaultValue(false);
            builder.Property(e => e.TodoId).HasColumnName("todo_id").IsRequired();

            builder.HasOne(e => e.Holder)
                .WithMany(e => e.Tasks)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
