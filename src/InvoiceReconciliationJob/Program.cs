using InvoiceReconciliationApi.Data;
using InvoiceReconciliationApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((ctx, svc) =>
    {
        svc.AddDbContext<InvoiceContext>(opts =>
            opts.UseSqlServer(ctx.Configuration.GetConnectionString("DefaultConnection")));
        svc.AddScoped<ReconciliationService>();
    })
    .Build();

using var sc = host.Services.CreateScope();
var svc = sc.ServiceProvider.GetRequiredService<ReconciliationService>();
await svc.RunAsync();