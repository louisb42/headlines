using Headline.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Headline.Common.ViewModels
{
    public interface IHeadlineMaintenanceViewModel
    {
        HeadlineModel? HeadlineBeforeEdit { get; set; }
        List<HeadlineModel> Headlines { get; set; }

        Task AddEmptyHeadline();
        void HandleEvent(HeadlineModel headline);
        void BackupItem(object headline);
        void ItemHasBeenCommitted(object headline);
        void ResetItemToOriginalValues(object headline);
    }
}
