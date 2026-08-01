using DiscordChatExporter.Core.Discord.Data;

namespace DiscordChatExporter.Core.Exporting.Filtering;

internal class LengthMessageFilter(int? minLength, int? maxLength) : MessageFilter
{
    public override bool IsMatch(Message message)
    {
        var length = message.Content.Length;

        if (minLength is not null && length < minLength.Value)
            return false;

        if (maxLength is not null && length > maxLength.Value)
            return false;

        return true;
    }
}
