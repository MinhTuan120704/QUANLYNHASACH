using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IReceiptDetailRepo
    {
        bool AddReceiptDetail(ReceiptDetail receiptDetail);
        bool DeleteReceiptDetail(ReceiptDetail receiptDetail);
        bool UpdateReceiptDetail(ReceiptDetail receiptDetail);
        List<ReceiptDetail> GetAllFromDB();
    }
}
