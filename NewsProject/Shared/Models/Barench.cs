using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Models
{
    public class Barench
    {
        public int BarenchID { get; set; }
        public string BarenchName { get; set; } 
        public string? Adderess { get; set; }
        public int CurrentStata { get; set; } = 1;
        public string? CreatUserID { get; set; }
        public DateTime? CreatDate { get; set; }
        public string? UpdateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? DeleteUserID { get; set; }
        public DateTime? DeleteDate { get; set; }

    }
}
