using ASPNetCoreWebApp_ConsumeAzureSQLServer.Models;
using ASPNetCoreWebApp_ConsumeAzureSQLServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetCoreWebApp_ConsumeAzureSQLServer.Pages
{
    public class IndexModel : PageModel
    {
        /*private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/
        public List<Product> products;
        public void OnGet()
        {
            ProductService productService = new ProductService();
            products = productService.GetProducts();
        }
    }
}