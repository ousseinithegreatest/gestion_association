using Microsoft.AspNetCore.Mvc;

namespace gestion_assoc.Controllers
{
    public class FinanceController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
