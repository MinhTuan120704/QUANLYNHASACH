using BLL.IServices;
using DAL.IRepo;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReceiptService : IReceiptService
    {
        private IReceiptRepo _receiptRepo;

        public ReceiptService()
        {
            _receiptRepo = new ReceiptRepo();
        }
        public bool AddReceipt(Receipt receipt)
        {
            _receiptRepo.AddReceipt(receipt);
            return true;
        }

        public bool DeleteReceipt(Receipt receipt)
        {
            _receiptRepo.DeleteReceipt(receipt);    
            return true;
        }

        public List<Receipt> GetAllReceipt()
        {
            return _receiptRepo.GetAllFromDB();
        }

        public bool UpdateReceipt(Receipt receipt)
        {
            _receiptRepo.UpdateReceipt(receipt);
            return true;
        }
    }
}
