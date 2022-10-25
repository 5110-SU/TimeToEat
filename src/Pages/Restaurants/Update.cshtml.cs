using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Pages.Restaurants
{
    public class UpdateModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        // Bind the data for the form
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }
        
        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet(string id)
        {
            // Get the product from the data storage
            Product = ProductService.GetProduct(id);
        }

        /// <summary>
        /// REST Post request to Update existing product
        /// </summary>
        /// <returns>Detail Page</returns>
        public IActionResult OnPost()
        {
            // Return to the page if the input data is not valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save updated product into database
            ProductModel product = ProductService.UpdateData(Product);

            if (product == null) {
                return RedirectToPage("./NotFound");
            }
            
            // Redirect user to the Updated restaurant detail page
            return RedirectToPage("./Detail", new {id = product.Id});
        }
    }
}