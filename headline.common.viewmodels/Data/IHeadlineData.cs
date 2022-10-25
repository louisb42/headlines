using headline.common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace headline.common.viewmodels.Data
{
    public interface IHeadlineData
    {
        Task<List<Headline>> GetDataAsync();
    }
}
