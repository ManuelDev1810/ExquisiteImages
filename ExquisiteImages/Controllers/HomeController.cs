using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using ExquisiteImages.Models;
using Newtonsoft.Json;

namespace ExquisiteImages.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:7001/")
        };

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync("/api/home");
            string stringResponse = await response.Content.ReadAsStringAsync();
            List<Image> Images = JsonConvert.DeserializeObject<List<Image>>(stringResponse);
            return View(Images);
        }
    }
}