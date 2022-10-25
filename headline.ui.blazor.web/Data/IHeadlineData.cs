using headline.common.Models;

namespace headline.ui.blazor.web.Data
{
    public interface IHeadlineData
    {
        Task<List<Headline>> GetDataAsync();
    }
}
