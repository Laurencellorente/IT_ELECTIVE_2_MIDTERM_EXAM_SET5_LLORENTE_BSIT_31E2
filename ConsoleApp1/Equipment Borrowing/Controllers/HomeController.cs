using Microsoft.AspNetCore.Mvc;

namespace Equipment_Borrowing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "EquipmentBorrowing");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}