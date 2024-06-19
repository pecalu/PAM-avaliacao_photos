using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ExemploHTTP.Models;
using System.Text.Json;
using System.Linq.Expressions;
using System.Diagnostics;

namespace ExemploHTTP.Services
{
    public class RestService
    {
        private HttpClient client;
        private Photo photo;
        private List<Photo> photos;
        private JsonSerializerOptions _serializerOptions;

        RestService()
        {
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Photo>> getPostsAsync()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/photos");

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    photos = JsonSerializer.Deserialize<List<Photo>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return photos;
        }
    }
}
