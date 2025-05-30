using InvoiceReconciliationApi.Models;
using Xunit;

public class InvoiceTests
{
    [Fact]
    public void PropertiesRoundTrip()
    {
        var inv = new Invoice { Vendor = "X", Amount = 100m };
        Assert.Equal("X", inv.Vendor);
        Assert.Equal(100m, inv.Amount);
    }
}