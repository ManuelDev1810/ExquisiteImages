using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExquisiteImages.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

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

        public async Task<Image> Create(Image model)
        {
            //Model
            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await client.PostAsync("/api/home/", httpContent);
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            Image data = JsonConvert.DeserializeObject<Image>(responseContent);
            return data;
        }
    }
}