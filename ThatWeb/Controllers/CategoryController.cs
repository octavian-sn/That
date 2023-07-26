using Microsoft.AspNetCore.Mvc;

namespace ThatWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
