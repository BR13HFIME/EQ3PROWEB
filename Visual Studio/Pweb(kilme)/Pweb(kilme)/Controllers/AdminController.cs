using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pweb_kilme_.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ReporteAdmin()
        {
            return View();
        }
        public IActionResult Conf_Reservaciones()
        {
            return View();
        }
    }
}
