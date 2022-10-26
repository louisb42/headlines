using System;
using System.Collections.Generic;

using Headline.Common.Models;

namespace Headline.Common.ViewModels
{
    public interface IHeadlinePresentationViewModel
    {
        List<HeadlineModel> Headlines { get; set; }
        TimeSpan CycleTime { get; set; }
    }
}
