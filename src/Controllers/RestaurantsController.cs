using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Restaurants Controller Class for API Endpoints and Web Pages Rendering
    /// </summary>
    [ApiController] // API Controller
    [Route("Restaurants/[controller]")] // API Endpoint
    public class RestaurantsController : ControllerBase
    {
        /// <summary>
        /// Restaurant Service Default Constructor 
        /// with Dependency Injection for Restaurant Service 
        /// </summary>
        /// <param name="restaurantService"></param>
        public RestaurantsController(JsonFileRestaurantService restaurantService)
        {
            RestaurantService = restaurantService;
        }
        
        // Restaurant Service Encapsulation Read Only Property
        public JsonFileRestaurantService RestaurantService { get; }

        // GET: Restaurants/
        [HttpGet]
        public IEnumerable<RestaurantModel> Get()
        {
            return RestaurantService.GetRestaurants();
        }
    }
}
