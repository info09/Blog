using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NetCore.Authorization.Roles;
using NetCore.Authorization.Users;
using NetCore.MultiTenancy;
using NetCore.Models;

namespace NetCore.EntityFrameworkCore
{
    public class NetCoreDbContext : AbpZeroDbContext<Tenant, Role, User, NetCoreDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public NetCoreDbContext(DbContextOptions<NetCoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostCategory>().HasKey(i => new { i.CategoryId, i.PostId });
            
        }
    }
}
