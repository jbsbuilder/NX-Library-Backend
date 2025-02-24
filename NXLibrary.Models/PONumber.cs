using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PONumber
    {
        public int Id { get; set; }
        public Vendor? Vendor { get; set; }
        public int? PONumbers { get; set; }
    }
}
