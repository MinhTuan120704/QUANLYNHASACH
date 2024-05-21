using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IReceiptDetailService
    {
        bool AddReceiptDetail(ReceiptDetail receiptDetail);
        bool DeleteReceiptDetail(ReceiptDetail receiptDetail);
        bool UpdateReceiptDetail(ReceiptDetail receiptDetail);
        List<ReceiptDetail> GetAllReceiptDetail();
    }
}
