namespace VoteWise.Models;

/// <summary>
/// Describes one labelled input in the account forms.
/// Used by the _FormField partial so every form field looks and behaves the same.
/// </summary>
/// <param name="Id">Input id/name attribute.</param>
/// <param name="Label">Visible label text.</param>
/// <param name="Icon">Icon name from IconHelper.</param>
/// <param name="Type">HTML input type (text, email, password...).</param>
/// <param name="Autocomplete">Browser autocomplete hint.</param>
/// <param name="Placeholder">Optional placeholder text.</param>
public record FormFieldViewModel(
    string Id,
    string Label,
    string Icon,
    string Type = "text",
    string Autocomplete = "off",
    string? Placeholder = null);
