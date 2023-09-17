using NewsProject.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace NewsProject.Shared.Models
{
    public class Product : BeasEntity
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "اسم المنتج مطلوبه ")]
        [MinLength(3, ErrorMessage = "اقل شيء ثلاثة احرف ")]
        public string ProductName { get; set; } 
        
        [Required(ErrorMessage = "تحديد السعر مطلوبه ")]
       
        public decimal Price { get; set; }
        [Required(ErrorMessage = " الكمية مطلوبه ")]
        public int Quntity { get; set; }
        public string? Img { get; set; }
        [Required(ErrorMessage = " نوع القسم  مطلوبه ")]
        public int CategoryId { get; set; } 
        public Category? Category { get; set; }



    }
}
