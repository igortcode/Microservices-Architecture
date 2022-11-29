using System.ComponentModel.DataAnnotations;

namespace MVC_Microservico.Models
{
    public class ProductViewModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
