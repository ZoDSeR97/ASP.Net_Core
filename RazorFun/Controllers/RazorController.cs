using Microsoft.AspNetCore.Mvc;
namespace TestController.Controllers;
public class TestController : Controller   // Remember inheritance?    
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()=>View();
    
}