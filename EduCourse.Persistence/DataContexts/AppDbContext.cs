﻿using Microsoft.EntityFrameworkCore;
using N67.Domain_.Entities;

namespace EduCourse.Persistence.DataContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> StudentCourses { get; set; }
        public DbSet<Role> Roles  => Set<Role>();


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
