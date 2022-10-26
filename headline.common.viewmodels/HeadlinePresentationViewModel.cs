using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

using Headline.Common.Models;
using Headline.Common.ViewModels.Data;

namespace Headline.Common.ViewModels
{
    public class HeadlinePresentationViewModel : IHeadlinePresentationViewModel
    {
        public List<HeadlineModel> Headlines { get; set; } = new List<HeadlineModel>();
        public TimeSpan CycleTime { get; set; } = TimeSpan.FromSeconds(7);

        private readonly IHeadlineData _headlineData;
        public HeadlinePresentationViewModel(IHeadlineData headlineData)
        {
            _headlineData = headlineData;
            List<HeadlineModel> result = Run.Sync(() => _headlineData.GetDataAsync());
            // #hack for now. Fix using an intermediate view-model
            foreach (HeadlineModel headline in result)
            {
                headline.BackgroundColour = $"background-color: {headline.BackgroundColour}";
            }
            Headlines = result;
        }
    }

    public static class Run
    {
        private static bool IsDotNetFx =>
            RuntimeInformation.FrameworkDescription.StartsWith(".NET Framework", StringComparison.OrdinalIgnoreCase);

        private static readonly TaskFactory factory =
            new TaskFactory(
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        public static TResult Sync<TResult>(Func<Task<TResult>> func)
        {
            if (IsDotNetFx)
            {
                return factory.StartNew(func).Unwrap().GetAwaiter().GetResult();
            }
            else
            {
                return func().GetAwaiter().GetResult();
            }
        }

        public static void Sync(Func<Task> func)
        {
            if (IsDotNetFx)
            {
                factory.StartNew(func).Unwrap().GetAwaiter().GetResult();
            }
            else
            {
                func().GetAwaiter().GetResult();
            }
        }
    }
}
