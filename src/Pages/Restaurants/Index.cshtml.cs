using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

         // The data to show on Restaurants Index Page
        public IEnumerable<ProductModel> Products;

        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="productService"></param>
        public IndexModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}