using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExquisiteImages.Models;
using Newtonsoft.Json;

namespace ExquisiteImages.Infrastructure.ImageClient
{
    public class ImageClient : IImageClient
    {
        static HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:7001/")
        };

        public async Task<List<Image>> Get()
        {
            HttpResponseMessage response = await client.GetAsync("/api/home");
            string stringResponse = await response.Content.ReadAsStringAsync();
            List<Image> images = JsonConvert.DeserializeObject<List<Image>>(stringResponse);
            return images;
        }
    }
}
