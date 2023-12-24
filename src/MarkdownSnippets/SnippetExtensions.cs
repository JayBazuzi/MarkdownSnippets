static class SnippetExtensions
{
    public static Dictionary<string, IReadOnlyList<Snippet>> ToDictionary(this IEnumerable<Snippet> value) =>
        value
            .GroupBy(_ => _.Key.ToLowerInvariant(), StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                keySelector: _ => _.Key.ToLowerInvariant(),
                elementSelector: _ => _.OrderBy(ScrubPath).ToReadonlyList(),
                comparer: StringComparer.OrdinalIgnoreCase);

    static string? ScrubPath(Snippet snippet) =>
        snippet.Path?
            .Replace("/", "")
            .Replace("\\", "");
}