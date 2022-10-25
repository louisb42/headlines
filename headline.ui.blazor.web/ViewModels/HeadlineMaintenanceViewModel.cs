using headline.common.Models;
using headline.ui.blazor.web.Data;
using Microsoft.JSInterop;
using MvvmBlazor.ViewModel;
using System.Diagnostics;

namespace headline.ui.blazor.web.ViewModels
{
    public class HeadlineMaintenanceViewModel : ViewModelBase, IHeadlineMaintenanceViewModel
    {
        public List<string> EditEvents { get; set; } = new();
        public Headline? SelectedItem1 { get; set; }
        public Headline? HeadlineBeforeEdit { get; set; }
        public List<Headline> Headlines { get; set; } = new List<Headline>();

        private readonly IJSInProcessRuntime _jsRuntime;
        private readonly IHeadlineData _headlineData;
        public HeadlineMaintenanceViewModel(IJSInProcessRuntime jsRuntime, IHeadlineData headlineData)
        {
            _jsRuntime = jsRuntime;
            _headlineData = headlineData;
            new Action(async () => Headlines = await _headlineData.GetDataAsync())();
        }

        public override async Task OnInitializedAsync()
        {

            var forecastData = await _headlineData.GetDataAsync();
        }


        public async Task AddEmptyHeadline()
        {
            int nextId = Headlines.OrderByDescending(h => h.Id).First().Id + 1;
            Headlines.Add(new Headline()
            {
                Id = nextId
            });
            await _jsRuntime.InvokeVoidAsync("window.scrollTo", 0, 1024);
        }

        public void ClearEventLog()
        {
            EditEvents.Clear();
        }

        public void HandleEvent(Headline headline)
        {
            Console.WriteLine(headline);
            Debug.WriteLine(headline);
        }

        public void BackupItem(object headline)
        {
            HeadlineBeforeEdit = new()
            {
                Id = ((Headline)headline).Id,
                Banner = ((Headline)headline).Banner,
                BackgroundColour = ((Headline)headline).BackgroundColour,
                ForegroundColour = ((Headline)headline).ForegroundColour,
                ImageUrl = ((Headline)headline).ImageUrl,
                Active = ((Headline)headline).Active
            };
        }

        public void ItemHasBeenCommitted(object headline)
        {
            HandleEvent((Headline)headline);
        }

        public void ResetItemToOriginalValues(object headline)
        {
            if (HeadlineBeforeEdit != null)
            {
                ((Headline)headline).Id = HeadlineBeforeEdit.Id;
                ((Headline)headline).Banner = HeadlineBeforeEdit.Banner;
                ((Headline)headline).BackgroundColour = HeadlineBeforeEdit.BackgroundColour;
                ((Headline)headline).ForegroundColour = HeadlineBeforeEdit.ForegroundColour;
                ((Headline)headline).ImageUrl = HeadlineBeforeEdit.ImageUrl;
                ((Headline)headline).Active = HeadlineBeforeEdit.Active;
            }
        }
    }
}
