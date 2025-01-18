using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using stok_takip_app.Models;

namespace stok_takip_app.Controllers;

public class HomeController : Controller
{

[HttpGet]
public IActionResult Index(string searchString, string category)
{
    var products = Repository.Products ?? new List<Product>();
    var categories = Repository.Categories ?? new List<Category>();

    if (!string.IsNullOrEmpty(searchString))
    {
        products = products.Where(i => i.Name.ToLower().Contains(searchString.ToLower())).ToList();
    }

    if (int.TryParse(category, out int categoryId))
    {
        products = products.Where(i => i.CategoryId == categoryId).ToList();
    }

    var model = new ProductViewModel
    {
        Products = products,
        Categories = categories,
        SelectedCategory = category ?? string.Empty,
        SearchString = searchString
    };

    return View(model);
}

    public IActionResult Privacy()
    {
        return View();
    }


}
