using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GraphQLBookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataBaseContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataBaseContext context)
        {
            _logger = logger;
            _context = context;
            // System.Console.WriteLine("---------------------------");
            // System.Console.WriteLine(_context.Books.Include(b => b.Author).First().Author.Name);
            // System.Console.WriteLine(_context.Authors.Include(b => b.Books).First().Books.First().Name);
            // System.Console.WriteLine("---------------------------");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
