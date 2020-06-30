﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;


namespace SlimFormaturas.Infra.Data.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.CourseId)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

            builder.HasMany(c => c.GraduateCeremonial)
               .WithOne(e => e.Course)
               .HasForeignKey(y => y.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
               
            builder.HasMany(c => c.ContractCourse)
                  .WithOne(e => e.Course)
                  .HasForeignKey(y => y.CourseId)
                  .OnDelete(DeleteBehavior.Cascade);
 
                  
            builder.ToTable("Course");
        }
    }
}
