using Microsoft.AspNetCore.Mvc;
using System.IO; 
using System.Collections.Generic;
using System.Text.Json;
using cainfo.Models;

namespace cainfo.Controllers
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
        private string filePath;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            filePath = "Public/data.json";
        }


        [HttpGet("GetName")]
        public Person GetName()
        {
            if (!System.IO.File.Exists(filePath))
            {
                Person newPerson = new();
                newPerson.Name = "Guido";
                newPerson.Age = 65;
                newPerson.Genre = "Masculine";

                

                return newPerson;
            }

            var json = System.IO.File.ReadAllText(filePath);
            Person person = JsonSerializer.Deserialize<Person>(json);

            return person;
        }
    }
}
