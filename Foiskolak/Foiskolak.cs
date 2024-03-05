using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Foiskolak
{
    public partial class Foiskola
    {
        [JsonProperty("alpha_two_code")]
        public string AlphaTwoCode { get; set; }

        [JsonProperty("web_pages")]
        public Uri[] WebPages { get; set; }

        [JsonProperty("state-province")]
        public object StateProvince { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("domains")]
        public string[] Domains { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public partial class Foiskola
    {
        public static Foiskola[] FromJson(string json) => JsonConvert.DeserializeObject<Foiskola[]>(json, Foiskolak.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Foiskola[] self) => JsonConvert.SerializeObject(self, Foiskolak.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
