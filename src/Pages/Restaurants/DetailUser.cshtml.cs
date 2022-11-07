using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Restaurants
{
    public class DetailUserModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        // The data to show
        public ProductModel Product;

        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="productService"></param>
        public DetailUserModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ProductService.GetProduct(id);
        }
    }
}
