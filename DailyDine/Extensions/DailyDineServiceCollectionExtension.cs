using DailyDine.Core.Common;
using DailyDine.Core.Contracts;
using DailyDine.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DailyDineServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
