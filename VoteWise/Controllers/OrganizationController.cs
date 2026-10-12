using Microsoft.AspNetCore.Mvc;
using VoteWise.Helpers;
using VoteWise.Models;

namespace VoteWise.Controllers;

/// <summary>
/// Organization dashboard screens (election setup, results, members, settings).
/// Front-end only: every action returns a view filled with hard-coded sample data.
/// </summary>
public class OrganizationController : Controller
{
    // ---------- Elections ----------

    // List of the organization's elections with a "Create an Election" button.
    public IActionResult Elections()
    {
        var elections = new List<ListCardViewModel>
        {
            new(SampleData.ElectionName,
                Subtitle: SampleData.OrganizationName,
                ButtonText: "View More",
                ButtonAction: nameof(ElectionResults))
        };

        return View(elections);
    }

    // Step 1 of creating an election: name, polling place and positions.
    public IActionResult CreateElection() => View();

    // Step 2: candidates for each position created in step 1.
    public IActionResult AddCandidates()
    {
        IReadOnlyList<string> positions = new[] { "President", "Vice President", "Secretary", "Treasurer" };
        return View(positions);
    }

    // Step 3: preview of the ballot before saving.
    public IActionResult ReviewBallot() => View(SampleData.PresidentBallot());

    // Results for one election, with the option to close the poll.
    public IActionResult ElectionResults() => View(SampleData.ElectionResults());

    // ---------- Members ----------

    // Members > Join Requests tab.
    public IActionResult Members()
    {
        var requests = Enumerable.Range(1, 4)
            .Select(_ => new ListCardViewModel(
                "Dela Cruz, Juan (24-1817)",
                ButtonText: "Accept",
                DangerButtonText: "Remove"))
            .ToList();

        return View(requests);
    }

    public IActionResult InviteStudent() => View();

    // Members > Pending Invitations tab.
    public IActionResult PendingInvitations()
    {
        var invitations = Enumerable.Range(1, 4)
            .Select(_ => new ListCardViewModel(
                "Dela Cruz, Juan (24-1817)",
                DangerButtonText: "Cancel Invite"))
            .ToList();

        return View(invitations);
    }

    // ---------- Settings ----------

    public IActionResult Settings() => View();
}
