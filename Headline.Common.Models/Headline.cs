using System.Text.Json.Serialization;

namespace Headline.Common.Models
{
    public class HeadlineModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("banner")]
        public string Banner { get; set; } = "";

        [JsonPropertyName("backgroundColour")]
        public string BackgroundColour { get; set; } = "#000000";

        [JsonPropertyName("foregroundColour")]
        public string ForegroundColour { get; set; } = "#ffffff";

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = "";

        [JsonPropertyName("active")]
        public bool Active { get; set; } = true;
    }
}
