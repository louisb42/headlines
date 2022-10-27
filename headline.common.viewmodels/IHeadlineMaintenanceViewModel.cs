using System.Collections.Generic;
using System.Threading.Tasks;

using Headline.Common.Models;

namespace Headline.Common.ViewModels
{
    public interface IHeadlineMaintenanceViewModel
    {
        HeadlineModel? HeadlineBeforeEdit { get; set; }
        List<HeadlineModel> Headlines { get; set; }

        Task LoadDataAsync();
        Task AddEmptyHeadline();
        Task HandleEvent(HeadlineModel headline);
        void BackupItem(object headline);
        void ItemHasBeenCommitted(object headline);
        void ResetItemToOriginalValues(object headline);
    }
}
