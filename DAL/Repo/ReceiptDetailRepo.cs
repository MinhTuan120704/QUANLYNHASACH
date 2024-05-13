using DAL.Context;
using DAL.IRepo;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ReceiptDetailRepo : IReceiptDetailRepo
    {
        private DatabaseContext _context;
        public ReceiptDetailRepo()
        {
            _context = new DatabaseContext();
        }
        public bool AddReceiptDetail(ReceiptDetail receiptDetail)
        {
            _context.ReceiptDetails.Add(receiptDetail);
            _context.SaveChanges();
            return true;
        }

        public List<ReceiptDetail> GetAllFromDB()
        {
            return _context.ReceiptDetails.ToList();
        }

        public bool DeleteReceiptDetail(ReceiptDetail receiptDetail)
        {
            _context.ReceiptDetails.Remove(receiptDetail);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateReceiptDetail(ReceiptDetail receiptDetail)
        {
            _context.ReceiptDetails.Update(receiptDetail);
            _context.SaveChanges();
            return true;
        }
    }
}
