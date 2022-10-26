using Headline.Common.ViewModels.Data;
using Headline.Common.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Headline.Common.ViewModels
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IHeadlineViewModel, HeadlineViewModel>();
            serviceCollection.AddScoped<IHeadlineMaintenanceViewModel, HeadlineMaintenanceViewModel>();
            serviceCollection.AddScoped<IHeadlinePresentationViewModel, HeadlinePresentationViewModel>();
            serviceCollection.AddScoped<IHeadlineData, HeadlineData>();

            return serviceCollection;
        }
    }
}
