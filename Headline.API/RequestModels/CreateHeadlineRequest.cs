using System.ComponentModel.DataAnnotations;

namespace Headline.API.RequestModels
{
    public class CreateHeadlineRequest
    {
        [Required]
        public string Banner { get; set; } = "";

        public string BackgroundColour { get; set; } = "#000000";

        public string ForegroundColour { get; set; } = "#ffffff";

        public string ImageUrl { get; set; } = "";

        public bool Active { get; set; } = true;
    }
}
