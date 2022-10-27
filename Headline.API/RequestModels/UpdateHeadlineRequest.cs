using System.ComponentModel.DataAnnotations;

namespace Headline.API.RequestModels
{
    public class UpdateHeadlineRequest
    {
        [Required]
        public string Banner { get; set; }

        public string BackgroundColour { get; set; }

        public string ForegroundColour { get; set; }

        public string ImageUrl { get; set; }

        public bool Active { get; set; }
    }
}
