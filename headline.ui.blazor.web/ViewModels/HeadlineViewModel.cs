using headline.common.Models;
using MvvmBlazor.ViewModel;

namespace headline.ui.blazor.web.ViewModels
{
    public class HeadlineViewModel : ViewModelBase, IHeadlineViewModel
    {
        private readonly Headline _headline;

        public HeadlineViewModel(Headline headline)
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
