﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Globalization;

public class TaxiService
{
    public async Task<string> GetTaxiFareAsync(double depLat, double depLng, double arrLat, double arrLng)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://taxi-fare-calculator.p.rapidapi.com/search-geo?dep_lat={depLat.ToString("G", CultureInfo.InvariantCulture)}&dep_lng={depLng.ToString("G", CultureInfo.InvariantCulture)}&arr_lat={arrLat.ToString("G", CultureInfo.InvariantCulture)}&arr_lng={arrLng.ToString("G", CultureInfo.InvariantCulture)}"),
            Headers =
    {
        { "X-RapidAPI-Key", "14d2270d82mshffd8f764f5b0265p12edafjsn377e5d65d3d9" },
        { "X-RapidAPI-Host", "taxi-fare-calculator.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            JObject jsonRespnse = JObject.Parse(body);
            return body;
        }
    }
}