using System;
using System.IO;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Osb.Core.Infrastructure.Data.MigrationsV2
{
    class Program
    {
        private static IConfiguration configuration;

        static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appSettings.json", false, true)
                .AddJsonFile($"appSettings.json", false, true)
                .AddEnvironmentVariables();

            configuration = builder.Build();

            

            // var serviceProvider = CreateServices();

            // // Put the database update into a scope to ensure
            // // that all resources will be disposed.
            // using (var scope = serviceProvider.CreateScope())
            // {
            //     UpdateDatabase(scope.ServiceProvider);
            // }
            
            var services = CreateServices();
            services.GetService<MigrationStart>().Run();
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices()
        {
            string connectionString = configuration.GetConnectionString("core");            
            Settings settings = configuration.GetSection("Settings").Get<Settings>();
            var services = new ServiceCollection();

            // return new ServiceCollection()
            //     // Add common FluentMigrator services
            //     .AddFluentMigratorCore()
            //     .ConfigureRunner(rb => rb
            //         // Add SQLite support to FluentMigrator
            //         .AddPostgres()
            //         // Set the connection string
            //         .WithGlobalConnectionString(connectionString)
            //         // Define the assembly containing the migrations
            //         .ScanIn(Assembly.GetAssembly(typeof(ScriptsMigration))).For.Migrations())
            //     //.ScanIn(Assembly.GetAssembly(typeof(UserCredentialMigration))).For.Migrations())
            //     // Enable logging to console in the FluentMigrator way
            //     .AddLogging(lb => lb.AddFluentMigratorConsole())
            //     // Build the service provider
            //     .BuildServiceProvider(false);


            services.AddLogging(configure => configure.AddConsole());

            services.AddSingleton(options => settings);


            services.AddFluentMigratorCore()
                .ConfigureRunner(cfg => cfg
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Program).Assembly).For.Migrations()
                )
                .AddLogging(cfg => cfg.AddFluentMigratorConsole());

            services.AddTransient<MigrationStart>();

            
            return services.BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        // private static void UpdateDatabase(IServiceProvider serviceProvider)
        // {

        //     string options = string.Empty;
        //     Console.WriteLine("Deseja executar as migrations? Sim / Não");
        //     options = Console.ReadLine();

        //     var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        //     if (options.ToLower().StartsWith("s"))
        //         runner.MigrateUp();

        //     Console.WriteLine("Deseja executar o rollback das migrations? Sim / Não");
        //     options = Console.ReadLine();

        //     if (options.ToLower().StartsWith("s"))
        //         runner.RollbackToVersion(0);
        // }
    }
}
