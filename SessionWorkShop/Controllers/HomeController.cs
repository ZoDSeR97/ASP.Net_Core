using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkShop.Models;

namespace SessionWorkShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index(){
        string? name = HttpContext.Session.GetString("User");
        if(!(name is null))
            return RedirectToAction("Dashboard");
        return View("Index");
    }

    [HttpGet("dashboard")]
    public IActionResult Dashboard(){
        string? name = HttpContext.Session.GetString("User");
        if(name is null)
            return RedirectToAction("Index");
        HttpContext.Session.SetInt32("Num", Users.users[name].num);
        return View();
    }

    [HttpGet("logout")]
    public IActionResult Logout(){
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpGet("math/{operation}")]
    public IActionResult CountMod(string operation){
        string? name = HttpContext.Session.GetString("User");
        if(name is null)
            return RedirectToAction("Index");
        switch(operation){
            case "+1":
                Users.users[name].num+=1;
                break;
            case "-1":
                Users.users[name].num-=1;
                break;
            case "x2":
                Users.users[name].num*=2;
                break;
            case "rng":
                Users.users[name].num+=new Random().Next();
                break;
            default:
                Console.WriteLine("WoW");
                break;
        }
        return RedirectToAction("Dashboard");
    }

    [HttpPost("process")]
    public IActionResult Process(User user){
        if(ModelState.IsValid){
            if (!Users.users.ContainsKey(user.name))
                Users.users.Add(user.name,user);
            HttpContext.Session.SetString("User", Users.users[user.name].name);
            HttpContext.Session.SetInt32("Num", Users.users[user.name].num);
            return RedirectToAction("Dashboard");
        }
        return Index();
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
