using Microsoft.EntityFrameworkCore;
using RabbitMQ_demo.Model;

namespace RabbitMQ_demo.Data
{
    public class ApplicationDBContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Product> Products
        {
            get;
            set;
        }
    }
}
