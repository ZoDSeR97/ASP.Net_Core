using Microsoft.AspNetCore.Mvc;
namespace FormController.Controllers;
public class FormController:Controller{
    [HttpGet]
    [Route("")]
    public ViewResult Index() => View();

    [HttpGet]
    [Route("results")]
    public ViewResult Result() => View();

    [HttpPost("process")]
    public IActionResult Process(string name, string location, string favLang, string comment=""){
        // TempData is only available for this and the next action
        TempData["name"] = name;
        TempData["location"] = location;
        TempData["favLang"] = favLang;
        TempData["comment"] = comment.Equals("")?"No comment":comment;
        return RedirectToAction("Result"); //TempData will be remove after this request is executed
    }
}