using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Pages.Restaurants
{
    public class CreateModel : PageModel
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
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }
        
        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
            // Create a new empty product object (all fields are null)
            Product = new ProductModel();
        }

        /// <summary>
        /// REST Post request to create a new product
        /// </summary>
        /// <returns>Detail Page</returns>
        public IActionResult OnPost()
        {
            // Return to the page if the input data is not valid
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            // Assign default value for product image if not set
            if (Product.Image == null)
            {
                Product.Image = "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/restaurant-instagram-post-advertisement-design-template-5e3dde31601916fac13b611b18066f52_screen.jpg?ts=1622274831";
            }

            // Assign default value for product url if not set
            if (Product.Url == null)
            {
                Product.Url = "https://time-to-eat.azurewebsites.net";
            }

            // Assign default value for product description if not set
            if (Product.Description == null)
            {
                Product.Description = "Seattle is a food lover’s dream! There are lots of great options so we’ve highlighted some of the best and most unique places to eat in Seattle, Washington.";
            }

             // Insert Product into database
            ProductModel product = ProductService.CreateProduct(Product);
            
            // Redirect user to the newly created restaurant detail page
            return RedirectToPage("./Detail", new {id = product.Id});
        }
    }
}