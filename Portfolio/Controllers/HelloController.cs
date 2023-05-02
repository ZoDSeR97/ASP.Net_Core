// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace TestController.Controllers;
public class HelloController : Controller   // Remember inheritance?    
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public ViewResult Index()=>View();
    
    // Route declaration Option B
    // This will go to "localhost:5XXX/projects"
    [HttpGet("projects")]
    public ViewResult Projects()=>View();

    [HttpGet("contact")]
    public ViewResult Contacts()=>View();
    
    
    // Post request example
    // This will go to "localhost:5XXX/submission"
    [HttpPost]
    [Route("submission")]
    // Don't worry about what the form is doing for now. We'll get to those soon!
    // Note: You will not be able to navigate to this route! This is for demonstration only!
    public string FormSubmission(string formInput)
    {
    	// Logic for post request here
        return "I handled a request!";
    }
}