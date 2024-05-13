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
    public class ReceiptRepo : IReceiptRepo
    {
        private DatabaseContext _context;
        public ReceiptRepo()
        {
            _context = new DatabaseContext();
        }
        public bool AddReceipt(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteReceipt(Receipt receipt)
        {
            _context.Receipts.Remove(receipt);
            _context.SaveChanges();
            return true;
        }

        public List<Receipt> GetAllFromDB()
        {
            return _context.Receipts.ToList();
        }

        public bool UpdateReceipt(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            _context.SaveChanges();
            return true;
        }
    }
}
