using System;
using System.Globalization;
using Avalonia.Data.Converters;
using DiscordChatExporter.Gui.Models;

namespace DiscordChatExporter.Gui.Converters;

public class FilterContentTypeToStringConverter : IValueConverter
{
    public static FilterContentTypeToStringConverter Instance { get; } = new();

    public object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    ) =>
        value is FilterContentType contentType
            ? contentType switch
            {
                FilterContentType.Link => "Links (has:link)",
                FilterContentType.Embed => "Embeds (has:embed)",
                FilterContentType.File => "Files (has:file)",
                FilterContentType.Video => "Videos (has:video)",
                FilterContentType.Image => "Images (has:image)",
                FilterContentType.Sound => "Audio / Sound (has:sound)",
                FilterContentType.Invite => "Invites (has:invite)",
                _ => "Any content / Любой контент",
            }
            : default;

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    ) => throw new NotSupportedException();
}
