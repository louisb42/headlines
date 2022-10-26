using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Headline.Common.Models;
using Headline.Common.ViewModels.Data;
using Headline.Common.ViewModels.Helpers;

namespace Headline.Common.ViewModels
{
    public class HeadlineMaintenanceViewModel : IHeadlineMaintenanceViewModel
    {
        public HeadlineModel? HeadlineBeforeEdit { get; set; }
        public List<HeadlineModel> Headlines { get; set; } = new List<HeadlineModel>();

        private readonly IHeadlineData _headlineData;
        public HeadlineMaintenanceViewModel(IHeadlineData headlineData)
        {
            _headlineData = headlineData;
            List<HeadlineModel> result = Run.Sync(() => _headlineData.GetDataAsync());
            Headlines = result;
        }

        public async Task AddEmptyHeadline()
        {
            Headlines.Add(new HeadlineModel() { Id = 0 });
        }

        public void HandleEvent(HeadlineModel headline)
        {
            Console.WriteLine(headline);
            Debug.WriteLine(headline);
            if (headline.Id > 0)
            {
                Run.Sync(() => _headlineData.PostDataAsync());
            }
            else
            {
                Run.Sync(() => _headlineData.PutDataAsync());
            }
        }

        public void BackupItem(object headline)
        {
            HeadlineBeforeEdit = new HeadlineModel()
            {
                Id = ((HeadlineModel) headline).Id,
                Banner = ((HeadlineModel) headline).Banner,
                BackgroundColour = ((HeadlineModel) headline).BackgroundColour,
                ForegroundColour = ((HeadlineModel) headline).ForegroundColour,
                ImageUrl = ((HeadlineModel) headline).ImageUrl,
                Active = ((HeadlineModel) headline).Active
            };
        }

        public void ItemHasBeenCommitted(object headline)
        {
            HandleEvent((HeadlineModel) headline);
        }

        public void ResetItemToOriginalValues(object headline)
        {
            if (HeadlineBeforeEdit != null)
            {
                ((HeadlineModel) headline).Id = HeadlineBeforeEdit.Id;
                ((HeadlineModel) headline).Banner = HeadlineBeforeEdit.Banner;
                ((HeadlineModel) headline).BackgroundColour = HeadlineBeforeEdit.BackgroundColour;
                ((HeadlineModel) headline).ForegroundColour = HeadlineBeforeEdit.ForegroundColour;
                ((HeadlineModel) headline).ImageUrl = HeadlineBeforeEdit.ImageUrl;
                ((HeadlineModel) headline).Active = HeadlineBeforeEdit.Active;
            }
        }
    }
}
