using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index(){
        ViewBag.AllProducts = _context.Products.ToList();
        return View("Index");
    }

    [HttpPost("")]
    public IActionResult AddProduct(Product p){
        if(ModelState.IsValid){
            _context.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return Index();
    }
    [HttpGet("categories")]
    public IActionResult Categories(){
        ViewBag.AllCategories = _context.Categories.ToList();
        return View("Categories");
    }
    [HttpPost("categories")]
    public IActionResult AddCategory(Category c){
        if(ModelState.IsValid){
            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        return Categories();
    }

    [HttpGet("products/{id}")]
    public IActionResult AProduct(int id){
        Product p = _context.Products.Include(p=>p.RelatedCategories).ThenInclude(a=>a.RelatedCategory).FirstOrDefault(p=>p.ProductId==id);
        ViewBag.Categories = _context.Categories.Include(c=>c.RelatedProducts).Where(c=>c.RelatedProducts.All(cp=>cp.ProductId!=id));
        ViewBag.Product = p;
        return View("Product");
    }
    [HttpPost("products/{id}")]
    public IActionResult AddCategoryToProduct(Association A){
        if(A.ProductId != 0 && A.CategoryId!=0){
            _context.Add(A);
            _context.SaveChanges();
            return RedirectToAction("AProduct",new {id=A.ProductId});
        }
        return AProduct(A.ProductId);
    }

    [HttpGet("categories/{id}")]
    public IActionResult ACategory(int id){
        Category c = _context.Categories.Include(c=>c.RelatedProducts).ThenInclude(a=>a.RelatedProduct).FirstOrDefault(c=>c.CategoryId==id);
        ViewBag.Products = _context.Products.Include(p=>p.RelatedCategories).Where(p=>p.RelatedCategories.All(pc => pc.CategoryId!=id));
        ViewBag.Category = c;
        return View("Category");
    }
    [HttpPost("categories/{id}")]
    public IActionResult AddProductToCategory(Association A){
        if(A.ProductId != 0 && A.CategoryId!=0){
            _context.Add(A);
            _context.SaveChanges();
            return RedirectToAction("ACategory",new {id=A.CategoryId});
        }
        return ACategory(A.CategoryId);
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
