using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Data.Entities;

namespace TodoList.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                {
                    continue;
                }
                if (entry.Entity is BaseEntity baseEntity)
                {
                    var now = DateTime.Now;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            baseEntity.CreatedAt = baseEntity.UpdatedAt = now;
                            break;
                        case EntityState.Modified:
                            baseEntity.UpdatedAt = now;
                            break;
                        case EntityState.Deleted:
                            baseEntity.UpdatedAt = now;
                            break;
                    }
                }
            }
        }
    }
}
