using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PONumber
    {
        public int Id { get; set; }
        [ForeignKey(nameof(VendorId))]
        public Vendor? Vendor { get; set; }
        public int? VendorId { get; set; }
        public int? PONumbers { get; set; }
    }
}
