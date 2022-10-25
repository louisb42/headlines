using headline.common.Models;
using headline.common.viewmodels.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace headline.common.ViewModels
{
    public class HeadlineMaintenanceViewModel : IHeadlineMaintenanceViewModel
    {
        public Headline? HeadlineBeforeEdit { get; set; }
        public List<Headline> Headlines { get; set; } = new List<Headline>();

        private readonly IHeadlineData _headlineData;
        public HeadlineMaintenanceViewModel(IHeadlineData headlineData)
        {
            _headlineData = headlineData;
            new Action(async () => Headlines = await _headlineData.GetDataAsync())();
        }

        public async Task AddEmptyHeadline()
        {
            await Task.Delay(0); // Appease the compiler for now.
            int nextId = Headlines.OrderByDescending(h => h.Id).First().Id + 1;
            Headlines.Add(new Headline()
            {
                Id = nextId
            });
            //await _jsRuntime.InvokeVoidAsync("window.scrollTo", 0, 1024);
        }

        public void HandleEvent(Headline headline)
        {
            Console.WriteLine(headline);
            Debug.WriteLine(headline);
        }

        public void BackupItem(object headline)
        {
            HeadlineBeforeEdit = new Headline()
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
