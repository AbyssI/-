using Microsoft.AspNetCore.Mvc;

namespace InternetStoreEngine.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
