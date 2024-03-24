using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather.Maui.Models
{
    public class Current
    {
        [JsonProperty("last_updated_epoch")]
        public long Last_updated_epoch { get; set; }

        [JsonProperty("last_updated")]
        public DateTime Last_updated { get; set; }

        [JsonProperty("temp_c")]
        public double Temp_c { get; set; }

        [JsonProperty("temp_f")]
        public double Temp_f { get; set; }

        [JsonProperty("is_day")]
        public int Is_day { get; set; }

        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        [JsonProperty("wind_mph")]
        public double Wind_mph { get; set; }

        [JsonProperty("wind_kph")]
        public double Wind_kph { get; set; }

        [JsonProperty("wind_degree")]
        public int Wind_degree { get; set; }

        [JsonProperty("wind_dir")]
        public string Wind_dir { get; set; }

        [JsonProperty("pressure_mb")]
        public int Pressure_mb { get; set; }

        [JsonProperty("pressure_in")]
        public double Pressure_in { get; set; }

        [JsonProperty("precip_mm")]
        public int Precip_mm { get; set; }

        [JsonProperty("precip_in")]
        public int Precip_in { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("cloud")]
        public int Cloud { get; set; }

        [JsonProperty("feelslike_c")]
        public double Feelslike_c { get; set; }

        [JsonProperty("feelslike_f")]
        public double Feelslike_f { get; set; }

        [JsonProperty("vis_km")]
        public int Vis_km { get; set; }

        [JsonProperty("vis_miles")]
        public int Vis_miles { get; set; }

        [JsonProperty("uv")]
        public int Uv { get; set; }

        [JsonProperty("gust_mph")]
        public double Gust_mph { get; set; }

        [JsonProperty("gust_kph")]
        public double Gust_kph { get; set; }
    }
}
