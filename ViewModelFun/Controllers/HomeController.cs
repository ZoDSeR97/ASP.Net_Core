using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index(){
        string message = """
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Esse est suscipit tempora soluta cupiditate, excepturi veniam vero illum, facere nisi ipsam eius quae omnis blanditiis cumque aperiam unde sapiente illo.
        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Saepe ad consequatur cumque exercitationem quod voluptatem, nostrum porro molestias, quaerat provident quae, harum atque possimus unde enim quis sapiente corrupti excepturi?
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis consequatur consequuntur dolore, iusto quisquam minima unde provident. Dicta, ullam! Delectus commodi ad minus vero exercitationem optio veritatis, neque nam eveniet.
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Eius corporis, ea esse libero fugiat a nihil ducimus suscipit exercitationem! Ab, nostrum asperiores. Suscipit itaque dolore odit ullam provident nulla sapiente.
        """;
        return View("Index", message);
    }

    [HttpGet("/numbers")]
    public IActionResult Numbers()=>View("Numbers", Enumerable.Range(1,7).Select(i=>new Random().Next(1, 31)).ToArray());

    [HttpGet("/user")]
    public IActionResult UserPage(){
        User user = new User("ZoDSeR", "SyLVaN");
        return View("User", user);
    }

    [HttpGet("/users")]
    public IActionResult Users(){
        User[] users = new User[]{
            new User("Neil", "Gaiman"),
            new User("Terry","Pratchet"),
            new User("Jane", "Austen"),
            new User("Stephen","King"),
            new User("Mary","Shelley")
        };
        return View("Users", users); 
    }

    public IActionResult Privacy()=> View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()=> View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
