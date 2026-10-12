using Microsoft.AspNetCore.Mvc;

namespace VoteWise.Controllers;

/// <summary>
/// Public-facing landing page. Front-end only: no data or logic.
/// </summary>
public class HomeController : Controller
{
    public IActionResult Index() => View();
}
