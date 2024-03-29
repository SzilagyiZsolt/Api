﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Idojaras;
//
//    var weather = Weather.FromJson(jsonString);
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Idojaras
{
    public class Weather
    {
        public static Dictionary<string, double> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, double>>(json, Idojaras.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Dictionary<string, double> self) => JsonConvert.SerializeObject(self, Idojaras.Converter.Settings);
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
