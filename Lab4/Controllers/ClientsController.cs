using Lab4.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            var dbContext = HttpContext.RequestServices.GetService<Lab4DbContext>();

            var clients = dbContext.Clients.ToList();

            return View(clients);
        }
    }
}
