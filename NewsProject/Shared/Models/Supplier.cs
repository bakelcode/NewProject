using System.ComponentModel.DataAnnotations;

namespace NewsProject.Shared.Models
{
    public class Supplier : BeasEntity
    {
        public int SupplierID { get; set; }
        [Required(ErrorMessage = "اسم العميل مطلوبه ")]
        [MinLength(3, ErrorMessage = "اقل شيء ثلاثة احرف ")]
        public string SupplierName { get; set; } 
        public string? Addrees { get; set; }
        public string? Phon { get; set; }
        public string? Img { get; set; }
        public string? Emil { get; set; }


    }
}
