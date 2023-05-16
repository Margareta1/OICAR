﻿using MapMyPathWeb.Models;
using MapMyPathWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MapMyPathWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult LiveFeed()
        {
            return View();
        }

        public async Task<IActionResult> WeatherInfo()
        {
            var ws = new WeatherService().GetWeatherFromOpenWeatherApi("Zagreb");
            await ws;
            var weather = ws.Result;
            ViewBag.WeatherInfo = weather;
            return View();
        }

        public IActionResult Routes()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}