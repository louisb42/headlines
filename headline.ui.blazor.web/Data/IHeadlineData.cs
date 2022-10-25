using headline.ui.blazor.web.Models;

namespace headline.ui.blazor.web.Data
{
    public interface IHeadlineData
    {
        Task<List<Headline>> GetDataAsync();
    }
}
