using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IReceiptRepo
    {
        bool AddReceipt(Receipt receipt);
        bool DeleteReceipt(Receipt receipt);
        bool UpdateReceipt(Receipt receipt);
        List<Receipt> GetAllFromDB();
    }
}
