using DiscordChatExporter.Core.Discord.Data;
using DiscordChatExporter.Core.Exporting.Filtering.Parsing;
using Superpower;

namespace DiscordChatExporter.Core.Exporting.Filtering;

public abstract partial class MessageFilter
{
    public abstract bool IsMatch(Message message);
}

public partial class MessageFilter
{
    public static MessageFilter Null { get; } = new NullMessageFilter();

    public static MessageFilter Parse(string value) => FilterGrammar.Filter.Parse(value);

    public static MessageFilter Length(int? minLength, int? maxLength) =>
        new LengthMessageFilter(minLength, maxLength);

    public static MessageFilter Combine(
        MessageFilter? baseFilter = null,
        string? fromUser = null,
        string? mentionsUser = null,
        MessageContentMatchKind? hasKind = null,
        bool? isPinned = null,
        string? includeWords = null,
        string? excludeWords = null,
        int? minLength = null,
        int? maxLength = null
    )
    {
        var filter = baseFilter ?? Null;

        void Append(MessageFilter nextFilter)
        {
            filter =
                filter == Null
                    ? nextFilter
                    : new BinaryExpressionMessageFilter(
                        filter,
                        nextFilter,
                        BinaryExpressionKind.And
                    );
        }

        if (!string.IsNullOrWhiteSpace(fromUser))
            Append(new FromMessageFilter(fromUser.Trim()));

        if (!string.IsNullOrWhiteSpace(mentionsUser))
            Append(new MentionsMessageFilter(mentionsUser.Trim()));

        if (hasKind is not null)
            Append(new HasMessageFilter(hasKind.Value));

        if (isPinned is not null)
        {
            var pinFilter = (MessageFilter)new HasMessageFilter(MessageContentMatchKind.Pin);
            Append(isPinned.Value ? pinFilter : new NegatedMessageFilter(pinFilter));
        }

        if (minLength is not null || maxLength is not null)
            Append(new LengthMessageFilter(minLength, maxLength));

        if (!string.IsNullOrWhiteSpace(includeWords))
        {
            foreach (var word in ParseWords(includeWords))
                Append(new ContainsMessageFilter(word));
        }

        if (!string.IsNullOrWhiteSpace(excludeWords))
        {
            foreach (var word in ParseWords(excludeWords))
                Append(new NegatedMessageFilter(new ContainsMessageFilter(word)));
        }

        return filter;
    }

    private static System.Collections.Generic.IEnumerable<string> ParseWords(string input)
    {
        char[] separators =
            input.Contains(',') || input.Contains(';') ? [',', ';'] : [' ', '\t', '\r', '\n'];

        return System.Linq.Enumerable.Where(
            System.Linq.Enumerable.Select(
                input.Split(separators, System.StringSplitOptions.RemoveEmptyEntries),
                w => w.Trim()
            ),
            w => !string.IsNullOrWhiteSpace(w)
        );
    }
}
