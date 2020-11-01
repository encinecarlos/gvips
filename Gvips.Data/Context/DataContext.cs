using Gvips.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Gvips.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
        
    }
}