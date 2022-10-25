namespace headline.ui.blazor.web.Models
{
    public class Headline
    {
        public int Id { get; set; }
        public string Banner { get; set; } = "";
        public string BackgroundColour { get; set; } = "";
        public string ForegroundColour { get; set; } = "";
        public string? ImageUrl { get; set; }
        public bool Active { get; set; } = true;
    }
}
