using headline.ui.blazor.web.Data;
using headline.ui.blazor.web.Models;
using Microsoft.JSInterop;


namespace headline.ui.blazor.web.ViewModels
{
    public class HeadlineMaintenanceViewModel : IHeadlineMaintenanceViewModel
    {
        public List<string> EditEvents { get; set; } = new();
        public Headline? SelectedItem1 { get; set; }
        public Headline? HeadlineBeforeEdit { get; set; }
        public List<Headline> Headlines { get; set; } = new List<Headline>();

        private HttpClient _client;
        private IJSInProcessRuntime _jsRuntime;
        private IHeadlineData _headlineData;
        public HeadlineMaintenanceViewModel(HttpClient client, IJSInProcessRuntime jsRuntime, IHeadlineData headlineData)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _jsRuntime = jsRuntime;
            _headlineData = headlineData;
            new Action(async () => Headlines = await _headlineData.GetDataAsync())();
        }

        public void AddEmptyHeadline()
        {
            int nextId = Headlines.OrderByDescending(h => h.Id).First().Id + 1;
            Headlines.Add(new Headline()
            {
                Id = nextId
            });
            _jsRuntime.InvokeVoidAsync("window.scrollTo", 0, 1024);
        }

        public void ClearEventLog()
        {
            EditEvents.Clear();
        }

        public void AddEditionEvent(string message)
        {
            EditEvents.Add(message);
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
            AddEditionEvent($"RowEditPreview event: made a backup of Headline {((Headline)headline).Id}");
        }

        public void ItemHasBeenCommitted(object headline)
        {
            AddEditionEvent($"RowEditCommit event: Changes to Headline {((Headline)headline).Id} committed");
        }

        public void ResetItemToOriginalValues(object headline)
        {
            ((Headline)headline).Id = HeadlineBeforeEdit.Id;
            ((Headline)headline).Banner = HeadlineBeforeEdit.Banner;
            ((Headline)headline).BackgroundColour = HeadlineBeforeEdit.BackgroundColour;
            ((Headline)headline).ForegroundColour = HeadlineBeforeEdit.ForegroundColour;
            ((Headline)headline).ImageUrl = HeadlineBeforeEdit.ImageUrl;
            ((Headline)headline).Active = HeadlineBeforeEdit.Active;
            AddEditionEvent($"RowEditCancel event: Editing of Headline {((Headline)headline).Id} cancelled");
        }
    }
}
