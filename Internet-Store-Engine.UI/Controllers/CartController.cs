using Microsoft.AspNetCore.Mvc;

namespace InternetStoreEngine.UI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
