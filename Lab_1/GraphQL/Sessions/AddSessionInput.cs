using GraphQL.Data.ConferencePlanner.GraphQL.Data;

namespace GraphQL.Sessions
{
    public record AddSessionInput(
       string Title,
       string? Abstract,
       [ID(nameof(Speaker))]
        IReadOnlyList<int> SpeakerIds);
}
