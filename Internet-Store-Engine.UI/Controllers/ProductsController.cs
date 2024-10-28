using Microsoft.AspNetCore.Mvc;

namespace InternetStoreEngine.UI.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
