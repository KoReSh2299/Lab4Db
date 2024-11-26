using Lab4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Controllers
{
    [ResponseCache(CacheProfileName = "CachingProfile")]
    public class ParkingSpacesController : Controller
    {
        public IActionResult Index()
        {
            var dbContext = HttpContext.RequestServices.GetService<Lab4DbContext>();

            var parkingSpaces = dbContext.ParkingSpaces.Include(prkSpc => prkSpc.Car).OrderBy(prkSpc => prkSpc.Id).ToList();

            return View(parkingSpaces);
        }
    }
}
