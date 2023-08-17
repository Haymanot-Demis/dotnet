using BlogPost.Domain.Common;
using BlogPost.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Infrastructure.Persistence.DBContext
{
    public class AppDBContext : DbContext
    {
        public DbSet<Post> posts { get; set; }
        public DbSet<Comment> comments { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedAt = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);
            builder.Entity<Post>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow);
            });

            builder.Entity<Comment>
            (entity => {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow);

                entity.HasOne(x => x.Post)
                    .WithMany(x => x.Comments)
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}
