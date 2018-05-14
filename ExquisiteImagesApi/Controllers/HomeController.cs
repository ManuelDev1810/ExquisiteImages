﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExquisiteImagesApi.Services.Interfaces;
using ExquisiteImagesApi.Models;
using System.Net.Http;

namespace ExquisiteImagesApi.Controllers
{
    [Route("api/Home")]
    public class HomeController : Controller
    {
        IImageRepository imageRepository;
        public HomeController(IImageRepository imgRepo)
        {
            imageRepository = imgRepo;
        }

        [HttpGet]
        public List<Image> Get() => imageRepository.Images();
        
    }
}