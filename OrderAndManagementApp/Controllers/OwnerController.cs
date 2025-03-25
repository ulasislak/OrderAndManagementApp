using Microsoft.AspNetCore.Mvc;

namespace OrderAndManagementApp.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
