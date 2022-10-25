using headline.common.Models;

namespace headline.ui.blazor.web.ViewModels
{
    public interface IHeadlineMaintenanceViewModel
    {
        List<string> EditEvents { get; set; }
        Headline? SelectedItem1 { get; set; }
        Headline? HeadlineBeforeEdit { get; set; }
        List<Headline> Headlines { get; set; }

        Task AddEmptyHeadline();
        void ClearEventLog();
        void HandleEvent(Headline headline);
        void BackupItem(object headline);
        void ItemHasBeenCommitted(object headline);
        void ResetItemToOriginalValues(object headline);
    }
}
