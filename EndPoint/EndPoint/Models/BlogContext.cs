using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Models
{
    public class BlogContext : IdentityDbContext<ApplicationUserModel>
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CommentModel>()
                .HasOne<PostModel>(s => s.Post)
                .WithMany(g => g.Comments)
                .HasForeignKey(s => s.PostID);

            modelBuilder.Entity<CommentModel>()
                .HasOne<ApplicationUserModel>(s => s.ApplicationUser)
                .WithMany(g => g.Comments)
                .HasForeignKey(s => s.UserGUID);
            
            modelBuilder.Entity<PostModel>()
                .HasOne<ApplicationUserModel>(s => s.ApplicationUser)
                .WithMany(g => g.Posts)
                .HasForeignKey(s => s.UserGUID);

            modelBuilder.Entity<PostModel>()
                .HasOne<ThemeModel>(s => s.Theme)
                .WithMany(g => g.Posts)
                .HasForeignKey(s => s.ThemeID);
        }

        public DbSet<ApplicationUserModel> ApplicationUsers { get; set; }
        public DbSet<ApplicationRoleModel> ApplicationRole { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
    }
}
