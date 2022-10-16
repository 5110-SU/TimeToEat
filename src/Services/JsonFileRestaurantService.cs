using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Restaurant Service Class for JSON File Data Access and Manipulation
    /// </summary>
    public class JsonFileRestaurantService
    {
        /// <summary>
        /// Restaurant Service Default Constructor  
        /// with Dependency Injection for Web Host Environment
        /// </summary>
        public JsonFileRestaurantService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Web Host Environment Encapsulation Read Only Property
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Restaurant Data File Path
        private string JsonFileName
        {
            get { 
                    return Path.Combine(
                        WebHostEnvironment.WebRootPath, 
                        "data", 
                        "products.json"
                    );
                }
        }

        // Get and Deserialize alll Restaurants from JSON File Data Source
        public IEnumerable<RestaurantModel> GetRestaurants()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                // Deserialize JSON File to retrieve all Restaurants
                return JsonSerializer.Deserialize<RestaurantModel[]>(
                    jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Ignore Case Sensitivity
                    });
            }
        }

        /// <summary>
        /// Serialize and Save restaurants data to JSON file storage
        /// </summary>
        private void SaveRestaurants(IEnumerable<RestaurantModel> restaurants)
        {
            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<RestaurantModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    restaurants
                );
            }
        }
    }
}