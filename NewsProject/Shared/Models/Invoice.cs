using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Models
{
    public class Invoice : BeasEntity
    {
        public int InvoiceId { get; set;}
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        [Range(0, 1000, ErrorMessage ="الخصم المطلوب يجب ان يكون بين 0 و 1000")]
        public decimal Discont { get; set; }
        public decimal Discontafter { get; set; }
        public decimal TotaEnd { get; set; } = 0;
        public int Qountte { get; set; } = 1;
      
        //public Users Opponent { get; set; }
        public int SuppId { get; set; }
        public Supplier? Supplier { get; set; } 
        public List<Invoicelist> InvoiceItemlist { get; set; } = new List<Invoicelist>();
      
  
    }
}
