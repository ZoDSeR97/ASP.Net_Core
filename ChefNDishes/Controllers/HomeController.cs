using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefNDishes.Models;

namespace ChefNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()=> View("Index", _context.Chefs.Include(c=>c.Dishes).ToList());

    [HttpGet("dishes")]
    public IActionResult Dishes()=> View("Dishes", _context.Dishes.Include(d=>d.Creator).ToList());

    [HttpGet("chefs/new")]
    public IActionResult NewChef()=>View("NewChef");
    [HttpPost("chefs/new")]
    public IActionResult AddChef(Chef newbie){
        if(ModelState.IsValid){
            _context.Add(newbie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return NewChef();
    }
    [HttpGet("dishes/new")]
    public IActionResult NewDish(){
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View("NewDish");
    }
    [HttpPost("dishes/new")]
    public IActionResult AddDish(Dish yummy){
        if(ModelState.IsValid){
            _context.Add(yummy);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        return NewDish();
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
