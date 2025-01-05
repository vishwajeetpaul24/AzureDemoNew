using AzureDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureDemo.Data
{
    public class AzureDemoDbContext:DbContext
    {
        public AzureDemoDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public  DbSet<formData> formData { get; set; }
    }
}
