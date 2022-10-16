using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Restaurant Model
    /// </summary>
    public class RestaurantModel
    {
        // Restaurant Unique Id
        public string Id { get; set; }

        // Restaurant Photo URL
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // Restaurant Website URL
        public string Url { get; set; }

        // Restaurant Name with length validation
        [StringLength(maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }

        // Restaurant Description
        public string Description { get; set; }

        // Restaurant Instance JSON Serialization
        public override string ToString() => JsonSerializer.Serialize<RestaurantModel>(this);
    }
}