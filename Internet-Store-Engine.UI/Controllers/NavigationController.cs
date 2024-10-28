using Microsoft.AspNetCore.Mvc;

namespace InternetStoreEngine.UI.Controllers
{
    public class NavigationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
