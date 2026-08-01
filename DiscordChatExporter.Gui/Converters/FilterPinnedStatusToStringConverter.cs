using System;
using System.Globalization;
using Avalonia.Data.Converters;
using DiscordChatExporter.Gui.Models;

namespace DiscordChatExporter.Gui.Converters;

public class FilterPinnedStatusToStringConverter : IValueConverter
{
    public static FilterPinnedStatusToStringConverter Instance { get; } = new();

    public object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    ) =>
        value is FilterPinnedStatus pinnedStatus
            ? pinnedStatus switch
            {
                FilterPinnedStatus.Yes => "Yes / Да (has:pin)",
                FilterPinnedStatus.No => "No / Нет (-has:pin)",
                _ => "Any / Любое",
            }
            : default;

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    ) => throw new NotSupportedException();
}
