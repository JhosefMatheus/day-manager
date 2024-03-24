using backend.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("task")]
[TokenRequired]
public class TaskController : ControllerBase
{
    [HttpPost]
    public ActionResult Index()
    {
        return Ok(new { message = "Task successfully created." });
    }
}