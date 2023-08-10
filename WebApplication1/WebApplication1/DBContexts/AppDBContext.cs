using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DBContexts
{
    public class AppDBContext: DbContext
    {
        public DbSet<User> Users { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
                        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity => {
                entity.HasKey(x => x.Id);
            });

            // modelBuilder.Entity<Post>(entity => {
            //     entity.HasKey(x => x.PostId);

            //     entity.HasMany(x => x.Comments)
            //         .WithOne(x => x.Post)
            //         .HasForeignKey(x => x.PostId);
            // });

            modelBuilder.Entity<Comment>(entity => {
                entity.HasKey(x => x.CommentId);

                entity.HasOne(x => x.Post)
                    .WithMany(x => x.Comments)
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
                    // .HasConstraintName("ForeignKey_Comment_Post");
            });
        }
    }
}
