using Microsoft.AspNetCore.Mvc;
using VoteWise.Helpers;
using VoteWise.Models;

namespace VoteWise.Controllers;

/// <summary>
/// Student dashboard screens. Front-end only: every action returns a view
/// filled with hard-coded sample data so the design can be reviewed.
/// </summary>
public class StudentController : Controller
{
    private const string ElectionName = SampleData.ElectionName;
    private const string OrganizationName = SampleData.OrganizationName;
    private const string LesitName = "League of Excellent Students in Information Technology";

    // ---------- Elections ----------

    // Elections > Ballots tab.
    public IActionResult Elections()
    {
        var elections = new List<ListCardViewModel>
        {
            new(ElectionName,
                Subtitle: OrganizationName,
                Meta: "Polling Place: IL101",
                ButtonText: "Vote Now",
                ButtonAction: nameof(Ballot))
        };

        return View(elections);
    }

    // First step of the official ballot (President).
    public IActionResult Ballot() => View(SampleData.PresidentBallot());

    // Review step before the vote is cast.
    public IActionResult ConfirmVote()
    {
        var selections = new List<SelectionViewModel>
        {
            new("President", "Juan Dela Cruz", "Nacionalista Party"),
            new("Vice President", "Juan Dela Cruz", "Nacionalista Party"),
            new("Secretary", "Juan Dela Cruz", "Nacionalista Party"),
            new("Treasurer", "Juan Dela Cruz", "Nacionalista Party")
        };

        return View(new ConfirmVoteViewModel(selections));
    }

    // Elections > Results tab.
    public IActionResult Results()
    {
        var elections = new List<ListCardViewModel>
        {
            new(ElectionName,
                Subtitle: OrganizationName,
                ButtonText: "View Results",
                ButtonAction: nameof(ResultDetails))
        };

        return View(elections);
    }

    // Full results for one election.
    public IActionResult ResultDetails() => View(SampleData.ElectionResults());

    // ---------- Organizations ----------

    // Organizations > My Organizations tab.
    public IActionResult Organizations()
    {
        var organizations = new List<ListCardViewModel>
        {
            new(ElectionName),
            new(LesitName)
        };

        return View(organizations);
    }

    // Organizations > Join an Organization tab.
    public IActionResult JoinOrganization()
    {
        var organizations = new List<ListCardViewModel>
        {
            new(ElectionName),
            new(LesitName),
            new(ElectionName),
            new(LesitName)
        };

        return View(organizations);
    }

    // Organizations > Invitations tab.
    public IActionResult Invitations()
    {
        var invitations = new List<ListCardViewModel>
        {
            new(OrganizationName,
                Meta: "You have been invited to join this organization.",
                ButtonText: "Accept")
        };

        return View(invitations);
    }

    // ---------- Candidacies ----------

    // Candidacies > Pending Invitations tab.
    public IActionResult Candidacies()
    {
        var pending = new List<ListCardViewModel>
        {
            new("LESIT 2026 Elections",
                Subtitle: LesitName,
                Highlight: "Vice President for Internal Affairs",
                ButtonText: "Accept")
        };

        return View(pending);
    }

    // Candidacies > Accepted Candidacies tab.
    public IActionResult AcceptedCandidacies()
    {
        var accepted = new List<ListCardViewModel>
        {
            new("LESIT 2026 Elections",
                Subtitle: LesitName,
                Highlight: "Vice President for Internal Affairs",
                ButtonText: "Edit Platform",
                ButtonAction: nameof(EditPlatform))
        };

        return View(accepted);
    }

    public IActionResult EditPlatform() => View();

    // ---------- Settings ----------

    public IActionResult Settings() => View();
}
