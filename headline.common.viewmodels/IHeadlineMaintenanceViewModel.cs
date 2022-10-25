using headline.common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace headline.common.ViewModels
{
    public interface IHeadlineMaintenanceViewModel
    {
        Headline? HeadlineBeforeEdit { get; set; }
        List<Headline> Headlines { get; set; }

        Task AddEmptyHeadline();
        void HandleEvent(Headline headline);
        void BackupItem(object headline);
        void ItemHasBeenCommitted(object headline);
        void ResetItemToOriginalValues(object headline);
    }
}
