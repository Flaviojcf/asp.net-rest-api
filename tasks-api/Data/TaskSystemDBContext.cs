using Microsoft.EntityFrameworkCore;
using tasks_api.Data.Map;
using tasks_api.Models;

namespace tasks_api.Data
{
    public class TaskSystemDBContext: DbContext
    {
        public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext>options): base(options) { }


        public DbSet<UserModel> Users { get; set; }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
