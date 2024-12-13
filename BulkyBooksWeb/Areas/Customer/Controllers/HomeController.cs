using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BulkyBooksWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.ProductRepository.GetAll(includeProperties:"Category").ToList();
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart shoppingCart = new()
            {
                Product = _unitOfWork.ProductRepository.Get(u => u.Id == productId, includeProperties: "Category"),
                ProductId = productId,
                Count = 1
            };
            return View(shoppingCart);
        }
        [HttpPost]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
           var claimsIdentity = (ClaimsIdentity)User.Identity;
           var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
           shoppingCart.ApplicationUserId = userId;
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCartRepository.Get(u=>u.ApplicationUserId == userId && u.ProductId==shoppingCart.ProductId);
            if (!(cartFromDb is null))
            {
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCartRepository.Update(cartFromDb);
            }
            else
            {
                _unitOfWork.ShoppingCartRepository.Add(shoppingCart);
            }
            TempData["Success"] = "Cart updated successfully!";
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
