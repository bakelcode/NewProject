using NewsProject.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Models
{
    public class InvoiceTemp : BeasEntity
    {

        public int InvoiceTempID { get; set; }

       

        [Required(ErrorMessage = "تحديد السعر مطلوبه ")]

        public decimal Price { get; set; }
        [Required(ErrorMessage = " الكمية مطلوبه ")]
        public int Quntity { get; set; }
        public decimal Total { get; set; }
        [Required(ErrorMessage = " نوع القسم  مطلوبه ")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = " نوع القسم  مطلوبه ")]
        public int ProductID { get; set; }
        public Product? Product { get; set; }






    }
}
