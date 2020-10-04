using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;
using TrampolineGuard.Shared;
using TrampolineGuard.Shared.Models;

namespace TrampolineGuard
{
    /// <summary>
    /// Time function that checks the weather, espacially the wind speed. Sends notifiction
    /// </summary>
    public class CheckWeather
    {
        private IConfiguration config;
        private INotify notify;

        public CheckWeather(IConfiguration config, INotify notify)
        {
            this.config = config;
            this.notify = notify;
        }

        [FunctionName("CheckWeather")]
        public void Run([TimerTrigger("0 30 10 * * SUN")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            using (var http = new WebClient())
            {
                var userAgent = config["userAgent"];
                var lat = config["lat"];
                var lng = config["lng"];
                var windLimit = double.Parse(config["windLimit"], new CultureInfo("en"));

                var sendWarning = false;
                
                // Fetch weather data from yr.no
                http.Headers.Add("User-Agent", userAgent);
                http.Headers.Add("Accept", "application/json");

                var request = $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={lat}&lon={lng}".Replace(",", ".");

                var dataStr = http.DownloadString(request);

                var data = JsonConvert.DeserializeObject<Temperatures>(dataStr);

                foreach (var d in data.Properties.Timeseries)
                {
                    if (d.Data.Instant.Details.WindSpeed >= windLimit) sendWarning = true;
                }
                
                // Check to see if application needs to send warning about wind speed
                if (sendWarning)
                {
                    notify.SendMessage(config["recipient"], config["warningMessage"]);
                }
                else
                {
                    notify.SendMessage(config["recipient"], config["serviceOkMessage"]);
                }
            }
        }
    }
}
