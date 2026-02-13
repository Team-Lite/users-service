using Microsoft.Extensions.DependencyInjection;
using UsersService.Application.Services;

namespace UsersService.Application;

public static class DependencyInjectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddServices()
        {
            return serviceCollection.AddScoped<IProfileService, ProfileService>();
        }
    }
}