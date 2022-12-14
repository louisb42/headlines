using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Headline.Common.Models;
using Headline.Common.ViewModels.Data;

namespace Headline.Common.ViewModels
{
    public class HeadlinePresentationViewModel : BaseViewModel, IHeadlinePresentationViewModel
    {
        public List<HeadlineModel> Headlines { get; set; } = new List<HeadlineModel>();
        public TimeSpan CycleTime { get; set; } = TimeSpan.FromSeconds(7);

        private readonly IHeadlineData _headlineData;

        public HeadlinePresentationViewModel(IHeadlineData headlineData)
        {
            _headlineData = headlineData;
        }

        public async Task LoadDataAsync()
        {
            try
            {
                List<HeadlineModel> result = await _headlineData.GetDataAsync();
                // #hack for now. Fix using an intermediate view-model
                foreach (HeadlineModel headline in result)
                {
                    headline.BackgroundColour = $"background-color: {headline.BackgroundColour}";
                }
                Headlines = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}
