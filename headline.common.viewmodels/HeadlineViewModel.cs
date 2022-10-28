using Headline.Common.Models;

namespace Headline.Common.ViewModels
{
    public class HeadlineViewModel : BaseViewModel, IHeadlineViewModel
    {
        private readonly HeadlineModel _headline;

        public HeadlineViewModel(HeadlineModel headline)
        {
            _headline = headline;
        }

        public int Id => _headline.Id;
        public string Banner => _headline.Banner;
        public string BackgroundColour => _headline.BackgroundColour;
        public string ForegroundColour => _headline.ForegroundColour;
        public string ImageUrl => _headline.ImageUrl;
        public bool Active => _headline.Active;
    }
}
