using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using MyTaskForSoftline.Repositories.Items;
using System.Linq;
using System.Threading.Tasks;


namespace MyTaskForSoftline.DAL
{
    public class DatabaseContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public DbSet<StatusItem> StatusItems { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IHttpContextAccessor httpContextAccessor) : base(options) {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskItem).Assembly);
        }

    }
}
