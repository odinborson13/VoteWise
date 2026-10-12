using Microsoft.AspNetCore.Mvc;
using VoteWise.Helpers;
using VoteWise.Models;

namespace VoteWise.Controllers;

/// <summary>
/// System administrator screens (elections, organization approvals, settings).
/// Front-end only: every action returns a view filled with hard-coded sample data.
/// </summary>
public class AdminController : Controller
{
    // ---------- Elections ----------

    // List of all elections with a "Create an Election" button.
    public IActionResult Elections()
    {
        var elections = new List<ListCardViewModel>
        {
            new(SampleData.ElectionName,
                Subtitle: SampleData.OrganizationName,
                ButtonText: "View Results",
                ButtonAction: nameof(ElectionResults))
        };

        return View(elections);
    }

    // Step 1 of creating an election (includes the Organization Name field).
    public IActionResult CreateElection() => View();

    // Step 2: candidates for each position.
    public IActionResult AddCandidates()
    {
        IReadOnlyList<string> positions = new[] { "President", "Vice President", "Secretary", "Treasurer" };
        return View(positions);
    }

    // Step 3: ballot preview before saving.
    public IActionResult ReviewBallot() => View(SampleData.PresidentBallot());

    // Results for one election, with the option to close the poll.
    public IActionResult ElectionResults() => View(SampleData.ElectionResults());

    // ---------- Organizations ----------

    // Organizations > All Organizations tab.
    public IActionResult Organizations()
    {
        var organizations = Enumerable.Range(1, 4)
            .Select(_ => new ListCardViewModel(
                "AWS Student Builder Group",
                Meta: "Organization ID: 123456789"))
            .ToList();

        return View(organizations);
    }

    // Organizations > Pending Approvals tab.
    public IActionResult PendingApprovals()
    {
        var names = new[]
        {
            "AWS Student Builder Group",
            "Junior Management Accountant Executives",
            "Iskolar Council",
            "Youth on the Rock"
        };

        var pending = names
            .Select(name => new ListCardViewModel(
                name,
                Meta: "Organization ID: 123456789",
                ButtonText: "Accept",
                DangerButtonText: "Remove"))
            .ToList();

        return View(pending);
    }

    // ---------- Settings ----------

    public IActionResult Settings() => View();
}
