namespace VoteWise.Models;

// View models shared by the student, organization and administrator dashboards.
// Front-end only: the controller fills these with sample data.

/// <summary>A tab in the white strip under the page header.</summary>
public record TabItem(string Text, string Action, bool IsActive = false);

/// <summary>
/// A rounded list row used for elections, organizations, invitations and candidacies.
/// Every text field except Title is optional. The button is optional too:
/// when ButtonAction is null the button renders as a plain (non-navigating) button.
/// DangerButtonText adds a red button after it (Remove, Cancel Invite...).
/// </summary>
public record ListCardViewModel(
    string Title,
    string? Subtitle = null,
    string? Meta = null,
    string? Highlight = null,
    string? ButtonText = null,
    string? ButtonAction = null,
    string? DangerButtonText = null);

/// <summary>One candidate on the ballot.</summary>
public record CandidateViewModel(string Value, string Name, string Party, string Platform);

/// <summary>A candidate plus the radio-group name, used by the _CandidateOption partial.</summary>
public record CandidateOptionViewModel(string GroupName, CandidateViewModel Candidate);

/// <summary>One step of the ballot (a single position).</summary>
public record BallotViewModel(
    string ElectionName,
    string PositionKey,
    string PositionTitle,
    int PositionNumber,
    int TotalPositions,
    int SlotsToSelect,
    IReadOnlyList<CandidateViewModel> Candidates);

/// <summary>A voter's choice for one position on the confirmation page.</summary>
public record SelectionViewModel(string Position, string CandidateName, string Party);

public record ConfirmVoteViewModel(IReadOnlyList<SelectionViewModel> Selections);

/// <summary>One ranked row in the election results.</summary>
public record ResultEntryViewModel(int Rank, string Name, string Party, int Votes);

public record PositionResultViewModel(string Position, IReadOnlyList<ResultEntryViewModel> Entries);

public record ElectionResultsViewModel(
    string ElectionName,
    IReadOnlyList<PositionResultViewModel> Positions);

/// <summary>A label + input row on the settings page (label left, input right).</summary>
/// <param name="TrailingIcon">Optional icon inside the input, e.g. "pencil" or "eye".</param>
public record SettingsRowViewModel(
    string Id,
    string Label,
    string Type = "text",
    string? TrailingIcon = null,
    string Autocomplete = "off",
    string? Placeholder = null);

/// <summary>Options for the shared "Create an Election" form.</summary>
/// <param name="ShowOrganizationName">True for the administrator, who creates elections on behalf of any organization.</param>
public record CreateElectionFormViewModel(bool ShowOrganizationName);
