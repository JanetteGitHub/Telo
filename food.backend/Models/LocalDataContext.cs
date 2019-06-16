namespace food.backend.Models
{
    using Domain.Models;

    public class LocalDataContext:DataContext
    {
        public System.Data.Entity.DbSet<food.common.Models.Product> Products { get; set; }
    }
}