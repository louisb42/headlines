using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Headline.Common.Models;
using Headline.Common.ViewModels.Data;

using Microsoft.VisualStudio.Threading;

namespace Headline.Common.ViewModels
{
    public class HeadlinePresentationViewModel : IHeadlinePresentationViewModel
    {
        public List<HeadlineModel> Headlines { get; set; } = new List<HeadlineModel>();
        public TimeSpan CycleTime { get; set; } = TimeSpan.FromSeconds(7);

        private readonly IHeadlineData _headlineData;

        private AsyncEventHandler _asyncEventHandler;
        public HeadlinePresentationViewModel(IHeadlineData headlineData)
        {
            _headlineData = headlineData;

            _asyncEventHandler += LoadDataAsync;

            Debug.WriteLine("Async invoke incoming!");
            _asyncEventHandler.InvokeAsync(this, EventArgs.Empty);
            Debug.WriteLine("Done.");
        }

        private async Task LoadDataAsync(object sender, EventArgs args)
        {
            try
            {
                List<HeadlineModel> result = _headlineData.GetDataAsync().Result;
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
