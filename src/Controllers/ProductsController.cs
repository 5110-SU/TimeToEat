using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Controller class for the products API endpoints.
    /// </summary>
    [Route("api/restaurants")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Contructor for ProductsController with service dependencie injection.
        /// </summary>
        /// <param name="productsService">The products data service</param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Data middle tier 
        public JsonFileProductService ProductService { get; }
        
        /// <summary>
        /// Get all products from controller base endpoints.
        /// </summary>
        /// <returns>HTTP 200 OK with JSON products in body</returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }
    }
}