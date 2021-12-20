﻿using ApiSdk;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph.Cli.Authentication;
using Microsoft.Graph.Cli.Commands.Authentication;
using Microsoft.Graph.Cli.Configuration;
using Microsoft.Graph.Cli.IO;
using Microsoft.Graph.Cli.Utils;
using Microsoft.Kiota.Authentication.Azure;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Graph.Cli
{
    class Program
    {
        const string SdkVersionHeaderValueFormatString = "{0}-cli-{1}.{2}.{3}";

        static async Task<int> Main(string[] args)
        {
            // We don't have access to a built host yet. Get configuration settings using a configuration builder.
            // Required to set initial token credentials.
            var configBuilder = new ConfigurationBuilder();
            ConfigureAppConfiguration(configBuilder);
            var config = configBuilder.Build();

            var authSettings = config.GetRequiredSection(Constants.AuthenticationSection).Get<AuthenticationOptions>();
            var authServiceFactory = new AuthenticationServiceFactory();
            var authStrategy = AuthenticationStrategy.DeviceCode;

            var credential = await authServiceFactory.GetTokenCredentialAsync(authStrategy, authSettings.TenantId, authSettings.ClientId);
            var authProvider = new AzureIdentityAuthenticationProvider(credential);
            var httpClient = new HttpClient();
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var sdkVersionHeaderValue = string.Format(
                SdkVersionHeaderValueFormatString,
                "graph",
                assemblyVersion.Major,
                assemblyVersion.Minor,
                assemblyVersion.Build);
            httpClient.DefaultRequestHeaders.Add("SdkVersion", sdkVersionHeaderValue);
            var core = new HttpClientRequestAdapter(authProvider, null, null, httpClient);
            var client = new GraphClient(core);
            var builder = BuildCommandLine(client);

            var loginCommand = new LoginCommand(authServiceFactory);
            builder.AddCommand(loginCommand.Build());

            var logoutCommand = new LogoutCommand(new LogoutService());
            builder.AddCommand(logoutCommand.Build());

            var parser = builder.UseHost(CreateHostBuilder).UseDefaults().Build();

            return await parser.InvokeAsync(args);
        }

        static CommandLineBuilder BuildCommandLine(GraphClient client)
        {
            var rootCommand = client.BuildCommand();
            rootCommand.Description = "Microsoft Graph CLI";

            return new CommandLineBuilder(rootCommand);
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder().ConfigureHostConfiguration((configHost) => {
                configHost.SetBasePath(Directory.GetCurrentDirectory());
            }).ConfigureAppConfiguration((ctx, config) => {
                var env = ctx.HostingEnvironment;
                ConfigureAppConfiguration(config);
                config.AddJsonFile($"app-settings.{env.EnvironmentName}.json", optional: true, true);
            }).ConfigureServices((ctx, services) => {
                var authSection = ctx.Configuration.GetSection(Constants.AuthenticationSection);
                services.Configure<AuthenticationOptions>(authSection);
                services.AddSingleton<IPathUtility, PathUtility>();
            });
        
        static void ConfigureAppConfiguration(IConfigurationBuilder builder) {
            builder.Sources.Clear();
            builder.AddJsonFile("app-settings.json", optional: true);
            var home = new PathUtility().GetUserHomeDirectory();
            var userConfigPath = Path.Combine(home, Constants.ApplicationDataDirectory, "settings.json");
            builder.AddJsonFile(userConfigPath);
            builder.AddEnvironmentVariables(prefix: "MGC_");
        }
    }
}
