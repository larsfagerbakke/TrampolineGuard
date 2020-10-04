/*
 * These classes was build by data example
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace TrampolineGuard.Shared.Models
{
    public partial class Temperatures
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }

    public partial class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }
    }

    public partial class Properties
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("timeseries")]
        public Timesery[] Timeseries { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("units")]
        public Units Units { get; set; }
    }

    public partial class Units
    {
        [JsonProperty("air_pressure_at_sea_level")]
        public string AirPressureAtSeaLevel { get; set; }

        [JsonProperty("air_temperature")]
        public string AirTemperature { get; set; }

        [JsonProperty("cloud_area_fraction")]
        public string CloudAreaFraction { get; set; }

        [JsonProperty("precipitation_amount")]
        public string PrecipitationAmount { get; set; }

        [JsonProperty("relative_humidity")]
        public string RelativeHumidity { get; set; }

        [JsonProperty("wind_from_direction")]
        public string WindFromDirection { get; set; }

        [JsonProperty("wind_speed")]
        public string WindSpeed { get; set; }
    }

    public partial class Timesery
    {
        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("instant")]
        public Instant Instant { get; set; }

        /*
        
        Not needed

        [JsonProperty("next_12_hours", NullValueHandling = NullValueHandling.Ignore)]
        public Next12_Hours Next12_Hours { get; set; }

        [JsonProperty("next_1_hours", NullValueHandling = NullValueHandling.Ignore)]
        public NextHours Next1_Hours { get; set; }

        [JsonProperty("next_6_hours", NullValueHandling = NullValueHandling.Ignore)]
        public NextHours Next6_Hours { get; set; }
        */
    }

    public partial class Instant
    {
        [JsonProperty("details")]
        public InstantDetails Details { get; set; }
    }

    public partial class InstantDetails
    {
        [JsonProperty("air_pressure_at_sea_level")]
        public double AirPressureAtSeaLevel { get; set; }

        [JsonProperty("air_temperature")]
        public double AirTemperature { get; set; }

        [JsonProperty("cloud_area_fraction")]
        public double CloudAreaFraction { get; set; }

        [JsonProperty("relative_humidity")]
        public double RelativeHumidity { get; set; }

        [JsonProperty("wind_from_direction")]
        public double WindFromDirection { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
    }

    public partial class Next12_Hours
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }

    public partial class Summary
    {
        [JsonProperty("symbol_code")]
        public SymbolCode SymbolCode { get; set; }
    }

    public partial class NextHours
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("details")]
        public Next1_HoursDetails Details { get; set; }
    }

    public partial class Next1_HoursDetails
    {
        [JsonProperty("precipitation_amount")]
        public double PrecipitationAmount { get; set; }
    }

    public enum SymbolCode { ClearSky, Cloudy, FairNight, Heavyrain, Lightrain, LightrainshowersNight, PartlycloudyDay, PartlycloudyNight, Rain, RainshowersNight };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                SymbolCodeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class SymbolCodeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SymbolCode) || t == typeof(SymbolCode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "cloudy":
                    return SymbolCode.Cloudy;
                case "fair_night":
                    return SymbolCode.FairNight;
                case "heavyrain":
                    return SymbolCode.Heavyrain;
                case "lightrain":
                    return SymbolCode.Lightrain;
                case "lightrainshowers_night":
                    return SymbolCode.LightrainshowersNight;
                case "partlycloudy_day":
                    return SymbolCode.PartlycloudyDay;
                case "partlycloudy_night":
                    return SymbolCode.PartlycloudyNight;
                case "rain":
                    return SymbolCode.Rain;
                case "rainshowers_night":
                    return SymbolCode.RainshowersNight;
                default:
                    return SymbolCode.ClearSky;
            }
            throw new Exception("Cannot unmarshal type SymbolCode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SymbolCode)untypedValue;
            switch (value)
            {
                case SymbolCode.Cloudy:
                    serializer.Serialize(writer, "cloudy");
                    return;
                case SymbolCode.FairNight:
                    serializer.Serialize(writer, "fair_night");
                    return;
                case SymbolCode.Heavyrain:
                    serializer.Serialize(writer, "heavyrain");
                    return;
                case SymbolCode.Lightrain:
                    serializer.Serialize(writer, "lightrain");
                    return;
                case SymbolCode.LightrainshowersNight:
                    serializer.Serialize(writer, "lightrainshowers_night");
                    return;
                case SymbolCode.PartlycloudyDay:
                    serializer.Serialize(writer, "partlycloudy_day");
                    return;
                case SymbolCode.PartlycloudyNight:
                    serializer.Serialize(writer, "partlycloudy_night");
                    return;
                case SymbolCode.Rain:
                    serializer.Serialize(writer, "rain");
                    return;
                case SymbolCode.RainshowersNight:
                    serializer.Serialize(writer, "rainshowers_night");
                    return;
                default:
                    serializer.Serialize(writer, "clearsky");
                    return;
            }
            throw new Exception("Cannot marshal type SymbolCode");
        }

        public static readonly SymbolCodeConverter Singleton = new SymbolCodeConverter();
    }
}
