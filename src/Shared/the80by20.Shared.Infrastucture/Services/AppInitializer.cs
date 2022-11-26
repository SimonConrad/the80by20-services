using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace the80by20.Shared.Infrastucture.Services
{
    internal class AppInitializer : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<AppInitializer> logger;

        // INFO
        // Because AppInitializer is registered as singleton then to get from ioc services which are 
        // registered as transient or scoped (w cannot inject them to singleton)
        // so we can use IServiceProvider to create scope and then get service from container
        public AppInitializer(IServiceProvider serviceProvider, ILogger<AppInitializer> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        // INFO for production environment installation seems that more reasonable is to run migrations manually or via some ci/cd step
        // for sandpit, test environment is ok
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(DbContext).IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext));

            using var scope = serviceProvider.CreateScope();
            foreach (var dbContextType in dbContextTypes)
            {
                var dbContext = scope.ServiceProvider.GetService(dbContextType) as DbContext;
                if (dbContext is null)
                {
                    continue;
                }

                await dbContext.Database.MigrateAsync(cancellationToken);
            }
                       
            await SeedWithData(scope, cancellationToken);
        }

        private static async Task SeedWithData(IServiceScope scope, CancellationToken cancellationToken)
        {
            var seederTypes = AppDomain.CurrentDomain.GetAssemblies()
               .SelectMany(x => x.GetTypes())
               .Where(x => typeof(IDataSeeder).IsAssignableFrom(x) && !x.IsInterface);

            foreach (var seederType in seederTypes)
            {
                var seeder = scope.ServiceProvider.GetService<IDataSeeder>();
                if (seeder is null)
                {
                    continue;
                }

                await seeder.Seed(scope, cancellationToken);
            }

        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
