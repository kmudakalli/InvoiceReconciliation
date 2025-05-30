using InvoiceReconciliationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceReconciliationApi.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> opts)
            : base(opts) { }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}