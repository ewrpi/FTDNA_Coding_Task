using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FTDNA_Coding_Task.Controllers
{
	using Models;

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
		private readonly DataContext _context;

		public SampleDataController(DataContext context)
		{
			_context = context;
		}

		[HttpGet("[action]")]
		public ActionResult Samples(string status, string nameSearch)
		{
			var data = _context.Samples.AsQueryable();
			if (!string.IsNullOrWhiteSpace(status))
				data = data.Where(s => s.Status.StatusName == status);
			if (!string.IsNullOrWhiteSpace(nameSearch))
				data = data.Where(s => s.CreatedBy.FirstName.Contains(nameSearch) || s.CreatedBy.LastName.Contains(nameSearch));

			return Json(data.Select(s => new {
				BarCode = s.Barcode,
				CreatedAt = s.CreatedAt.ToString(),
				Status = s.Status.StatusName,
				CreatedBy = s.CreatedBy.FirstName + " " + s.CreatedBy.LastName
			}));

		}

		[HttpGet("[action]")]
		public ActionResult Add(string barcode, string name, string status)
		{
			if (string.IsNullOrWhiteSpace(barcode))
				return BadRequest("Bar Code is required");

			User user = _context.Users.FirstOrDefault(u => u.FirstName + " " + u.LastName == name);
			if (user == null)
				return BadRequest("No user exists with full name [" + name + "]");

			Status stat = _context.Statuses.FirstOrDefault(s => s.StatusName == status);
			if (stat == null)
				return BadRequest("Status [" + status + "] does not exist");

			Sample dupe = _context.Samples.FirstOrDefault(s => s.Barcode == barcode);
			if (dupe != null)
				return BadRequest("Sample with barcode " + barcode + " already exists, try again.");

			Sample newsample = new Sample {
				Barcode = barcode,
				CreatedById = user.UserId,
				CreatedBy = user,
				Status = stat,
				StatusId = stat.StatusId,
				CreatedAt = DateTime.UtcNow
			};
			_context.Samples.Add(newsample);
			_context.SaveChanges();

			return Ok("HTTP OK");
		}

		#region template code
		private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

		#endregion
	}
}
