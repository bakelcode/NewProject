using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        [MinLength(5, ErrorMessage = "Atleast 5 chars required")]
        public string CategoryName { get; set; }
        //[Compare("CategoryName", ErrorMessage = "Name not matched")]
        //public string ConfirmeName { get; set; }
    }
}
