﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HoaDon
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string state { get; set; }
        public int khachHangId { get; set; }
    }
}
