using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

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
        ViewBag.Dishes = _context.Dishes.ToList();
        return View();
    }

    [HttpGet("dishes/{id}")]
    public IActionResult SingleDish(int id){
        ViewBag.Dish = _context.Dishes.FirstOrDefault(i => i.DishId == id);
        return View("Dish");
    }

    [HttpGet("dishes/new")]
    public IActionResult NewDish()=>View("New");

    [HttpPost("dishes/new")]
    public IActionResult NewDish(Dish d){
        if(ModelState.IsValid){
            _context.Add(d);
            _context.SaveChanges();
            return Redirect($"{d.DishId}");
        }
        return NewDish();
    }
    [HttpGet("dishes/{id}/edit")]
    public IActionResult EditDish(int id){
        ViewBag.Dish = _context.Dishes.FirstOrDefault(item=>item.DishId==id);
        return View("Edit", ViewBag.Dish);
    }

    [HttpPost("dishes/{id}/edit")]
    public IActionResult EditDish(int id, Dish d){
        // Find the old version of the instance in your database
        Dish? Old = _context.Dishes.FirstOrDefault(i => i.DishId == id);
        if(ModelState.IsValid && Old!=null){
            Old.Name = d.Name;
            Old.Chef = d.Chef;
            Old.Tastiness = d.Tastiness;
            Old.Calories = d.Calories;
            Old.Description = d.Description;
            Old.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return Redirect($"/dishes/{id}");
        }
        return EditDish(id);
    }

    [HttpPost("dishes/{id}/delete")]
    public IActionResult RemoveDish(int id){
        Dish? d = _context.Dishes.SingleOrDefault(i => i.DishId == id);
        if (d!=null){
            _context.Dishes.Remove(d);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
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
