using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TrampolineGuard;
using TrampolineGuard.Shared;

[assembly: WebJobsStartup(typeof(Startup))]
namespace TrampolineGuard
{        
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            // Read and add secrets and environment variables in config
            var config = new ConfigurationBuilder()
               .AddUserSecrets(Assembly.GetExecutingAssembly(), false)
               .AddEnvironmentVariables()
               .Build();

            // Inject services
            builder.Services.AddSingleton<IConfiguration>(config);
            builder.Services.AddSingleton<INotify>(new SMSNotify(config["onlineServiceAuthId"], config["onlineServiceAuthToken"], config["onlineServiceSource"]));
        }
    }
}
