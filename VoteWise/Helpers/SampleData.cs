using VoteWise.Models;

namespace VoteWise.Helpers;

/// <summary>
/// Hard-coded sample data shared by more than one controller.
/// Front-end only: replace with real data once a back end exists.
/// </summary>
public static class SampleData
{
    public const string ElectionName = "Supreme Student Council 2026 Elections";
    public const string OrganizationName = "Supreme Student Council";

    /// <summary>First step of the ballot (President) with four placeholder candidates.</summary>
    public static BallotViewModel PresidentBallot()
    {
        var candidates = Enumerable.Range(1, 4)
            .Select(i => new CandidateViewModel(
                Value: $"president-{i}",
                Name: "Juan Dela Cruz",
                Party: "Nacionalista Party",
                Platform: "Placeholder for the platform description"))
            .ToList();

        return new BallotViewModel(
            ElectionName,
            PositionKey: "president",
            PositionTitle: "President",
            PositionNumber: 1,
            TotalPositions: 14,
            SlotsToSelect: 1,
            Candidates: candidates);
    }

    /// <summary>Vote counts for President and Vice President.</summary>
    public static ElectionResultsViewModel ElectionResults()
    {
        PositionResultViewModel BuildPosition(string title) => new(
            title,
            Enumerable.Range(1, 4)
                .Select(rank => new ResultEntryViewModel(rank, "Juan dela Cruz", "Nacionalista", 10_000))
                .ToList());

        return new ElectionResultsViewModel(
            ElectionName,
            new[] { BuildPosition("President"), BuildPosition("Vice President") });
    }
}
