using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Restaurants
{
    /// <summary>
    /// Restaurant Index Page Model
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="restaurantService"></param>
        public IndexModel(JsonFileRestaurantService restaurantService)
        {
            RestaurantService = restaurantService;
        }
        // Data middletier
        public JsonFileRestaurantService RestaurantService { get; }
        
        // The data to show
        public IEnumerable<RestaurantModel> Restaurants { get; private set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
            Restaurants = RestaurantService.GetRestaurants();
        }
    }
}