using headline.common.viewmodels.Data;
using headline.common.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace headline.common.viewmodels
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
