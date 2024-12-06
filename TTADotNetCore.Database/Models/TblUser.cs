using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTADotNetCore.Database.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? MobileNumber { get; set; }
        public decimal? Balance { get; set; }
        public string? Pin { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
