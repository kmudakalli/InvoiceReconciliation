namespace InvoiceReconciliationApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}