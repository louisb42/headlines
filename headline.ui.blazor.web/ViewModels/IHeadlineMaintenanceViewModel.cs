using headline.common.Models;

namespace headline.ui.blazor.web.ViewModels
{
    public interface IHeadlineMaintenanceViewModel
    {
        List<string> EditEvents { get; set; }
        Headline? SelectedItem1 { get; set; }
        Headline? HeadlineBeforeEdit { get; set; }
        List<Headline> Headlines { get; set; }

        void AddEmptyHeadline();
        void ClearEventLog();
        void AddEditionEvent(string message);
        void BackupItem(object headline);
        void ItemHasBeenCommitted(object headline);
        void ResetItemToOriginalValues(object headline);
    }
}
