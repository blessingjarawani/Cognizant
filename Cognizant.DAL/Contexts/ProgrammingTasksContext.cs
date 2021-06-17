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
