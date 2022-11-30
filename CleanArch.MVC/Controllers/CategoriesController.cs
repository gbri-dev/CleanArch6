using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
