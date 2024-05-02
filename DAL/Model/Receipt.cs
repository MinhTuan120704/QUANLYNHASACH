using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Receipt
    {
        public int ReceiptID { get; set; }

        public DateTime ReceiptDate { get; set; }

        public int Total {  get; set; }

        public List<ReceiptDetail> receiptDetailsR { get; set; }
    }
}
