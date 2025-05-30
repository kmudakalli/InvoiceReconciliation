using InvoiceReconciliationApi.Models;

namespace InvoiceReconciliationApi.Services
{
    public class QuickBooksService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;

        public QuickBooksService(IConfiguration cfg)
        {
            _http = new HttpClient();
            _baseUrl = cfg["QuickBooks:BaseUrl"];
        }

        public Task<List<Invoice>> FetchOutstandingAsync()
        {
            throw new NotImplementedException();
        }
    }
}