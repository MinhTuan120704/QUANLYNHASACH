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
    public class ReceiptDetailService : IReceiptDetailService
    {
        private IReceiptDetailRepo _receiptDetailRepo;

        public ReceiptDetailService()
        {
            _receiptDetailRepo = new ReceiptDetailRepo();
        }
        public bool AddReceiptDetail(ReceiptDetail receiptDetail)
        {
            _receiptDetailRepo.AddReceiptDetail(receiptDetail); 
            return true;
        }

        public bool DeleteReceiptDetail(ReceiptDetail receiptDetail)
        {
            _receiptDetailRepo.DeleteReceiptDetail(receiptDetail);
            return true;
        }

        public List<ReceiptDetail> GetAllReceiptDetail()
        {
            return _receiptDetailRepo.GetAllFromDB();
        }

        public bool UpdateReceiptDetail(ReceiptDetail receiptDetail)
        {
            _receiptDetailRepo.UpdateReceiptDetail(receiptDetail);
            return true;
        }
    }
}
