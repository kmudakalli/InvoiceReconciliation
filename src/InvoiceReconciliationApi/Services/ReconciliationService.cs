using InvoiceReconciliationApi.Data;
using Microsoft.EntityFrameworkCore;

namespace InvoiceReconciliationApi.Services
{
    public class ReconciliationService
    {
        private readonly InvoiceContext _ctx;
        private readonly EmailService _email;

        public ReconciliationService(InvoiceContext ctx, EmailService email)
        {
            _ctx = ctx;
            _email = email;
        }

        public async Task RunAsync()
        {
            var invs = await _ctx.Invoices.ToListAsync();
            var pos = await _ctx.PurchaseOrders.ToListAsync();
            var pays = await _ctx.Payments.ToListAsync();

            var errs = invs.Where(i =>
                !pos.Any(po => po.Id == i.PurchaseOrderId && po.Amount == i.Amount) ||
                !pays.Any(p => p.Id == i.PaymentId && p.Amount == i.Amount))
                .ToList();

            if (errs.Any())
            {
                var msg = string.Join("\n", errs.Select(e => $"Invoice {e.Id} mismatch"));
                await _email.SendAsync("accounting@company.com",
                    "Reconciliation Alert", msg);
            }
        }
    }
}