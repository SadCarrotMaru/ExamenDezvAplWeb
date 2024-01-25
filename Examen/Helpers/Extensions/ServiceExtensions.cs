
using Repositories.TestRepository;
using Services.TestService;

namespace Helpers.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ITestRepository, TestRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<ITestService, TestService>();

        return services;
    }

    //public static IServiceCollection AddSeeders(this IServiceCollection services)
    //{
    //    services.AddTransient<TestSeeder>();

    //    return services;
    //}
}