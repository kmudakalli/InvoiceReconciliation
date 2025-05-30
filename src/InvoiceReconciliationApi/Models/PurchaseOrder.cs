namespace InvoiceReconciliationApi.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string PoNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}