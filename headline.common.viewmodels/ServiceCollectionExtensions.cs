using Headline.Common.ViewModels.Data;

using Microsoft.Extensions.DependencyInjection;

namespace Headline.Common.ViewModels
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection serviceCollection)
        {
            _ = serviceCollection.AddTransient<IHeadlineViewModel, HeadlineViewModel>();
            _ = serviceCollection.AddScoped<IHeadlineMaintenanceViewModel, HeadlineMaintenanceViewModel>();
            _ = serviceCollection.AddScoped<IHeadlinePresentationViewModel, HeadlinePresentationViewModel>();
            _ = serviceCollection.AddScoped<IHeadlineData, HeadlineData>();

            return serviceCollection;
        }
    }
}
