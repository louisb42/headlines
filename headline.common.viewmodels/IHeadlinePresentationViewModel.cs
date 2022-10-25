using headline.common.Models;
using System;
using System.Collections.Generic;

namespace headline.common.ViewModels
{
    public interface IHeadlinePresentationViewModel
    {
        List<Headline> Headlines { get; set; }
        TimeSpan CycleTime { get; set; }
    }
}
