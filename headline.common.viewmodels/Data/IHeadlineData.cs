using System.Collections.Generic;
using System.Threading.Tasks;
using Headline.Common.Models;

namespace Headline.Common.ViewModels.Data
{
    public interface IHeadlineData
    {
        Task<List<HeadlineModel>> GetDataAsync();
    }
}
