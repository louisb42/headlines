using headline.common.Models;
using headline.common.viewmodels.Data;
using System;
using System.Collections.Generic;

namespace headline.common.ViewModels
{
    public class HeadlinePresentationViewModel : IHeadlinePresentationViewModel
    {
        public List<Headline> Headlines { get; set; } = new List<Headline>();
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
