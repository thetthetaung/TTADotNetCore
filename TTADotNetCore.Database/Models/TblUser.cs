﻿using System;
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
        public string? MoobileNumber { get; set; }
        public string? Balance { get; set; }
        public string? Pin { get; set; }
    }
}
