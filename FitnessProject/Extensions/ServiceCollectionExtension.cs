namespace Microsoft.Extensions.DependencyInjection 
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Services;
    using FitnessProject.Infrastructure.Data;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleManagerService, RoleManagerService>();
            services.AddScoped<IUserManagerService, UserManagerService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
