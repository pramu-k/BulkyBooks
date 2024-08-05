using Microsoft.AspNetCore.Mvc;

namespace BulkyBooksWeb.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
