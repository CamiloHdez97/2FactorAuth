using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence;

    public class ApiContext : DbContext
    {

        
        public DbSet<User> Users { get; set; }
        
        public ApiContext(DbContextOptions<ApiContext> options) : base(options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }

