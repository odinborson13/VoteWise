using Microsoft.AspNetCore.Mvc;

namespace VoteWise.Controllers;

/// <summary>
/// Authentication screens (role selection, sign-up, sign-in).
/// Front-end only: every action simply returns its view.
/// </summary>
public class AccountController : Controller
{
    // Step 1 of "Login to Vote": choose Student or Organization.
    public IActionResult SelectRole() => View();

    public IActionResult SignUpStudent() => View();

    public IActionResult SignUpOrganization() => View();

    public IActionResult SignIn() => View();
}
