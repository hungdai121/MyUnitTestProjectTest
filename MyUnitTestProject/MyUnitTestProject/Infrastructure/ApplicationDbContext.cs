using Microsoft.EntityFrameworkCore;
using MyUnitTestProject.Models;

namespace MyUnitTestProject.Infrastructure
{
    public class ApplicationDbContext: DbContext
    {
        static readonly string connectionString = "Server=localhost;port=3306;user=root;password=123456;database=My_Test_Db";

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
