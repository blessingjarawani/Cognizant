using Cognizant.DAL.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cognizant.DAL.Contexts
{
    public class ProgrammingTasksContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<GameStats> GameStats { get; set; }
        public DbSet<ProgrammingLanguages> ProgrammingLanguages { get; set; }
        public ProgrammingTasksContext(DbContextOptions<ProgrammingTasksContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProgrammingLanguages>().HasData(
                new ProgrammingLanguages
                {
                    Id=1,
                    Name = "JAVA",
                    KeyCode = "java",
                    BaseSolutionCode = @"public class MyClass { " +
                                         " public static void main(String args[]) " +
                                         "{                " +
                                         
                                         "}}",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsActive = true
                },

                new ProgrammingLanguages
                {
                    Id = 2,
                    Name = "PHP",
                    KeyCode = "php",
                    BaseSolutionCode = @"<?php ,         
                                          
                                             ?> ",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsActive = true
                }
            );
            modelBuilder.Entity<Tasks>().HasData(
                new Tasks
                {
                    Id = 1,
                    Name = "Fibonacci Series",
                    Description = "Given a number n, print n-th Fibonacci Number.",
                    InputParameter = "9",
                    ExpectedOutPut = "34",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsActive = true
                },
                new Tasks
                {
                    Id = 2,
                    Name = "Sum of elements array",
                    Description = "Program to find sum of elements in a given array elements InputArray 12,3,4,15",
                    InputParameter = "0",
                    ExpectedOutPut = "34",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsActive = true
                });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var addedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            addedEntities.ForEach(E =>
            {
                E.Property("CreatedDate").CurrentValue = DateTime.Now;

            });

            var editedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            editedEntities.ForEach(E =>
            {
                E.Property("CreatedDate").IsModified = false;
                E.Property("UpdatedDate").CurrentValue = DateTime.Now;

            });

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
