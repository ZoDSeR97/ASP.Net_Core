using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers;
public class WeddingController:Controller{
    private readonly ILogger<WeddingController> _logger;
    MyContext _context;
    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [SessionCheck]
    [HttpGet("Weddings")]
    public IActionResult Index(){
        ViewBag.User = _context.Users.FirstOrDefault(u=>u.UserId==HttpContext.Session.GetInt32("UserId"));
        return View("Index", _context.Weddings.Include(w=>w.Guests).ToList());
    }
    [SessionCheck]
    [HttpGet("Weddings/{id}")]
    public IActionResult Wedding(int id){
        ViewBag.User = _context.Users.FirstOrDefault(u=>u.UserId==HttpContext.Session.GetInt32("UserId"));
        return View("Wedding", _context.Weddings
            .Include(w=>w.Guests)
            .ThenInclude(a=>a.User)
            .FirstOrDefault(w=>w.WeddingId==id));
    }
    [SessionCheck]
    [HttpGet("Weddings/new")]
    public IActionResult NewWedding(){
        ViewBag.User = _context.Users.FirstOrDefault(u=>u.UserId==HttpContext.Session.GetInt32("UserId"));
        return View("NewWedding");
    }
    [SessionCheck]
    [HttpPost("Weddings/new")]
    public IActionResult AddWedding(Wedding w){
        if(ModelState.IsValid){
            w.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(w);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return NewWedding();
    }
    [SessionCheck]
    [HttpPost("Weddings/{id}/delete")]
    public IActionResult RemoveWedding(int id){
        Wedding w = _context.Weddings.FirstOrDefault(w=>w.WeddingId==id);
        if (w!=null){
            _context.Remove(w);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    [SessionCheck]
    [HttpGet("Weddings/{id}/RSVP")]
    public IActionResult AddRSVP(int id){
        Attend a = new Attend(){
            UserId=(int)HttpContext.Session.GetInt32("UserId"), 
            WeddingId=id
        };
        _context.Add(a);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [SessionCheck]
    [HttpGet("Weddings/{id}/RemoveRSVP")]
    public IActionResult RemoveRSVP(int id){
        Attend a = _context.Attends.FirstOrDefault(
            guest=> guest.UserId == (int)HttpContext.Session.GetInt32("UserId") 
            && guest.WeddingId==id);
        if (a!=null){
            _context.Remove(a);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpGet("Weddings/logout")]
    public IActionResult logout(){
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
    // Name this anything you want with the word "Attribute" at the end
    public class SessionCheckAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            // Find the session, but remember it may be null so we need int?
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            // Check to see if we got back null
            if(userId == null) {
                // Redirect to the Index page if there was nothing in session
                // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}