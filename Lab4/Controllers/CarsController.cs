using Lab4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            var dbContext = HttpContext.RequestServices.GetService<Lab4DbContext>();

            var cars = dbContext.Cars.Include(car => car.Client).ToList();

            return View(cars);
        }
    }
}
