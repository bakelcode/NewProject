using NewsProject.Shared.Models;

namespace NewsProject.Shared.Dtos
{
    public class ProductDto
    {
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quntity { get; set; }
        public decimal Price { get; set; }
       
        public byte[]? NewImg { get; set; }
        public string? Img { get; set; }
        public int? BarenchId { get; set; }
        
        public int CategoryId { get; set; } 
       
       

    }
}
