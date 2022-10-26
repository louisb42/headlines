using Headline.Common.Models;
using Headline.Common.ViewModels.Data;
using System;
using System.Collections.Generic;

namespace Headline.Common.ViewModels
{
    public class HeadlinePresentationViewModel : IHeadlinePresentationViewModel
    {
        public List<HeadlineModel> Headlines { get; set; } = new List<HeadlineModel>();
        public TimeSpan CycleTime { get; set; } = TimeSpan.FromSeconds(7);

        private readonly IHeadlineData _headlineData;
        public HeadlinePresentationViewModel(IHeadlineData headlineData)
        {
            _headlineData = headlineData;
            new Action(async () => Headlines = await _headlineData.GetDataAsync())();
            // #hack for now. Fix using an intermediate view-model
            foreach (var headline in Headlines)
            {
                headline.BackgroundColour = $"background-color: {headline.BackgroundColour}";
            }
        }
    }
}
