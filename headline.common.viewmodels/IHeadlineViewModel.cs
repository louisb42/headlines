namespace headline.common.ViewModels
{
    public interface IHeadlineViewModel
    {
        bool Active { get; }
        string BackgroundColour { get; }
        string Banner { get; }
        string ForegroundColour { get; }
        int Id { get; }
        string ImageUrl { get; }
    }
}