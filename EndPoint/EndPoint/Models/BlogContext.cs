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

        public DbSet<ApplicationUserModel> ApplicationUsers { get; set; }
        public DbSet<ApplicationRoleModel> ApplicationRole { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
    }
}
