using Newtonsoft.Json;

namespace FreeGeoIp
{
    public class GeoIpResponse
    {
        public string Ip { get; set; }
        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }
        [JsonProperty(PropertyName = "country_name")]
        public string CountryName { get; set; }
        [JsonProperty(PropertyName = "region_code")]
        public string RegionCode { get; set; }
        [JsonProperty(PropertyName = "region_name")]
        public string RegionName { get; set; }
        public string City { get; set; }
        [JsonProperty(PropertyName = "zip_code")]
        public string ZipCode { get; set; }
        [JsonProperty(PropertyName = "time_zone")]
        public string TimeZone { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        [JsonProperty(PropertyName = "metro_code")]
        public int MetroCode { get; set; }
    }
}