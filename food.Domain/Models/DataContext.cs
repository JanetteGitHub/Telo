
namespace food.Domain.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext 
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<food.common.Models.Product> Products { get; set; }
    }
}
