using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookStoreService.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
