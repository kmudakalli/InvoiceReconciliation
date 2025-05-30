using InvoiceReconciliationApi.Data;
using InvoiceReconciliationApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceReconciliationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceContext _ctx;

        public InvoicesController(InvoiceContext ctx) => _ctx = ctx;

        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] Invoice invoice)
        {
            _ctx.Invoices.Add(invoice);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = invoice.Id }, invoice);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetById(int id)
        {
            var inv = await _ctx.Invoices
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Payment)
                .FirstOrDefaultAsync(i => i.Id == id);

            return inv is null ? NotFound() : inv;
        }
    }
}