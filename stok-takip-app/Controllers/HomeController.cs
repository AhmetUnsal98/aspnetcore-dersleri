using System.Diagnostics;
using System.Threading.Tasks;
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
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories =  new SelectList(Repository.Categories , "CategoryId","CategoryName");
        return View();
    }
[HttpPost]
public async Task<IActionResult> Create(Product model, IFormFile imageFile)
{
    if (imageFile == null)
    {
        Console.WriteLine("imageFile NULL");
        ViewBag.Categories = new SelectList(Repository.Categories ?? new List<Category>(), "CategoryId", "CategoryName");
        return View(model);
    }

    var extension = Path.GetExtension(imageFile.FileName);
    var randomFileName = $"{Guid.NewGuid()}{extension}";
    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

    if (ModelState.IsValid)
    {
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }
        model.ProductId = (Repository.Products?.Count() ?? 0) + 1;
        Repository.CreatePorduct(model);
        return RedirectToAction("Index");
    }

    ViewBag.Categories = new SelectList(Repository.Categories ?? new List<Category>(), "CategoryId", "CategoryName");
    return View(model);
}
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if(id == null) 
        {
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if(entity == null)
        {
            return NotFound();
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "CategoryName");
        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile)
    {
        if(id != model.ProductId)
        {
            return NotFound();
        }

        if(ModelState.IsValid)
        {
            if(imageFile != null) 
            {
                var extension = Path.GetExtension(imageFile.FileName); // abc.jpg
                var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                model.Image = randomFileName;
            }
            Repository.EditProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "CategoryName");
        return View(model);
    }

    public IActionResult Delete(int? id)
    {
        if(id == null)
        {
            return NotFound();        
        }

        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if(entity == null)
        {
            return NotFound();
        }

        return View("DeleteConfirm", entity);
    }

    [HttpPost]
    public IActionResult Delete(int id, int ProductId)
    {
        if(id != ProductId)
        {
            return NotFound();
        }

        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == ProductId);
        if(entity == null)
        {
            return NotFound();
        }

        Repository.DeleteProduct(entity);
        return RedirectToAction("Index");
    }

}
