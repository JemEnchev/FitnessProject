namespace Microsoft.Extensions.DependencyInjection 
{
    using FitnessProject.Core.Contracts;
    using FitnessProject.Core.Services;
    using FitnessProject.Infrastructure.Data;
    using FitnessProject.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IRoleManagerService, RoleManagerService>();
            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<ISupplementService, SupplementService>();
            services.AddScoped<ISupplementBrandService, SupplementBrandService>();
            services.AddScoped<ISupplementFlavourService, SupplementFlavourService>();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IWorkoutService, WorkoutService>();

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
