

namespace food.backend.Models
{
    
    using System.Web;
    using common.Models;
    public class ProductView:Product
    {
        public HttpPostedFileBase ImageFile { get; set; }

    }
}