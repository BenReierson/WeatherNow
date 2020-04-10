using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WeatherNow.Models
{
    public partial class LocationWeather
    {
        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lat { get; set; }

        [JsonProperty("lon", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lon { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string? Timezone { get; set; }

        [JsonProperty("current", NullValueHandling = NullValueHandling.Ignore)]
        public CurrentWeather? Current { get; set; }

        [JsonProperty("hourly", NullValueHandling = NullValueHandling.Ignore)]
        public List<Hourly>? Hourly { get; set; }

        [JsonProperty("daily", NullValueHandling = NullValueHandling.Ignore)]
        public List<Daily>? Daily { get; set; }
    }

    public partial class CurrentWeather
    {
        [JsonProperty("dt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Dt { get; set; }

        [JsonProperty("sunrise", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sunrise { get; set; }

        [JsonProperty("sunset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sunset { get; set; }

        [JsonProperty("temp", NullValueHandling = NullValueHandling.Ignore)]
        public double? Temp { get; set; }

        [JsonProperty("feels_like", NullValueHandling = NullValueHandling.Ignore)]
        public double? FeelsLike { get; set; }

        [JsonProperty("pressure", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pressure { get; set; }

        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Humidity { get; set; }

        [JsonProperty("dew_point", NullValueHandling = NullValueHandling.Ignore)]
        public double? DewPoint { get; set; }

        [JsonProperty("uvi", NullValueHandling = NullValueHandling.Ignore)]
        public double? Uvi { get; set; }

        [JsonProperty("clouds", NullValueHandling = NullValueHandling.Ignore)]
        public long? Clouds { get; set; }

        [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
        public long? Visibility { get; set; }

        [JsonProperty("wind_speed", NullValueHandling = NullValueHandling.Ignore)]
        public double? WindSpeed { get; set; }

        [JsonProperty("wind_deg", NullValueHandling = NullValueHandling.Ignore)]
        public long? WindDeg { get; set; }

        [JsonProperty("weather", NullValueHandling = NullValueHandling.Ignore)]
        public List<Weather>? Weather { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public Rain? Rain { get; set; }
    }

    public partial class Rain
    {
        [JsonProperty("1h", NullValueHandling = NullValueHandling.Ignore)]
        public double? The1H { get; set; }
    }

    public partial class Weather
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("main", NullValueHandling = NullValueHandling.Ignore)]
        public string? Main { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string? Icon { get; set; }

        [JsonIgnore]
        public string? IconImage => $"https://openweathermap.org/img/wn/{Icon}@2x.png";
    }

    public partial class Daily
    {
        [JsonProperty("dt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Dt { get; set; }

        [JsonProperty("sunrise", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sunrise { get; set; }

        [JsonProperty("sunset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sunset { get; set; }

        [JsonProperty("temp", NullValueHandling = NullValueHandling.Ignore)]
        public Temp? Temp { get; set; }

        [JsonProperty("feels_like", NullValueHandling = NullValueHandling.Ignore)]
        public FeelsLike? FeelsLike { get; set; }

        [JsonProperty("pressure", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pressure { get; set; }

        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Humidity { get; set; }

        [JsonProperty("dew_point", NullValueHandling = NullValueHandling.Ignore)]
        public double? DewPoint { get; set; }

        [JsonProperty("wind_speed", NullValueHandling = NullValueHandling.Ignore)]
        public double? WindSpeed { get; set; }

        [JsonProperty("wind_deg", NullValueHandling = NullValueHandling.Ignore)]
        public long? WindDeg { get; set; }

        [JsonProperty("weather", NullValueHandling = NullValueHandling.Ignore)]
        public List<Weather>? Weather { get; set; }

        [JsonProperty("clouds", NullValueHandling = NullValueHandling.Ignore)]
        public long? Clouds { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public double? Rain { get; set; }

        [JsonProperty("uvi", NullValueHandling = NullValueHandling.Ignore)]
        public double? Uvi { get; set; }
    }

    public partial class FeelsLike
    {
        [JsonProperty("day", NullValueHandling = NullValueHandling.Ignore)]
        public double? Day { get; set; }

        [JsonProperty("night", NullValueHandling = NullValueHandling.Ignore)]
        public double? Night { get; set; }

        [JsonProperty("eve", NullValueHandling = NullValueHandling.Ignore)]
        public double? Eve { get; set; }

        [JsonProperty("morn", NullValueHandling = NullValueHandling.Ignore)]
        public double? Morn { get; set; }
    }

    public partial class Temp
    {
        [JsonProperty("day", NullValueHandling = NullValueHandling.Ignore)]
        public double? Day { get; set; }

        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public double? Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public double? Max { get; set; }

        [JsonProperty("night", NullValueHandling = NullValueHandling.Ignore)]
        public double? Night { get; set; }

        [JsonProperty("eve", NullValueHandling = NullValueHandling.Ignore)]
        public double? Eve { get; set; }

        [JsonProperty("morn", NullValueHandling = NullValueHandling.Ignore)]
        public double? Morn { get; set; }
    }

    public partial class Hourly
    {
        [JsonProperty("dt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Dt { get; set; }

        [JsonProperty("temp", NullValueHandling = NullValueHandling.Ignore)]
        public double? Temp { get; set; }

        [JsonProperty("feels_like", NullValueHandling = NullValueHandling.Ignore)]
        public double? FeelsLike { get; set; }

        [JsonProperty("pressure", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pressure { get; set; }

        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Humidity { get; set; }

        [JsonProperty("dew_point", NullValueHandling = NullValueHandling.Ignore)]
        public double? DewPoint { get; set; }

        [JsonProperty("clouds", NullValueHandling = NullValueHandling.Ignore)]
        public long? Clouds { get; set; }

        [JsonProperty("wind_speed", NullValueHandling = NullValueHandling.Ignore)]
        public double? WindSpeed { get; set; }

        [JsonProperty("wind_deg", NullValueHandling = NullValueHandling.Ignore)]
        public long? WindDeg { get; set; }

        [JsonProperty("weather", NullValueHandling = NullValueHandling.Ignore)]
        public List<Weather>? Weather { get; set; }

        [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
        public Rain? Rain { get; set; }
    }

    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters ={new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }},
    //    };
    //}
}
