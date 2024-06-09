using DAL.Configuration;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {

        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookOrder> BookOrders { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        public virtual DbSet<Constraints> Constraints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new BookOrderConfig());
            modelBuilder.ApplyConfiguration(new ConsumerConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new ReceiptConfig());
            modelBuilder.ApplyConfiguration(new ReceiptDetailConfig());
            modelBuilder.ApplyConfiguration(new ConstraintsConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI;Database=QuanLyNhaSach;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }
    }
}
