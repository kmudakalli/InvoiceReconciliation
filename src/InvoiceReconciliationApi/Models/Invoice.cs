namespace InvoiceReconciliationApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Vendor { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}