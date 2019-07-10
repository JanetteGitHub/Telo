
namespace food.Domain.Models
{
    using common.Models;
    using System.Data.Entity;
    public class DataContext:DbContext 
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
