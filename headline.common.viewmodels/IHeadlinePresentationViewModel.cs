using Headline.Common.Models;
using System;
using System.Collections.Generic;

namespace Headline.Common.ViewModels
{
    public interface IHeadlinePresentationViewModel
    {
        List<HeadlineModel> Headlines { get; set; }
        TimeSpan CycleTime { get; set; }
    }
}
