using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ReceiptDetail
    {
        public int ReceiptID { get; set; }

        public int BookID { get; set; }

        public int Quantity { get; set; }

        public Book Book { get; set; }

        public Receipt Receipt { get; set; }
    }
}
