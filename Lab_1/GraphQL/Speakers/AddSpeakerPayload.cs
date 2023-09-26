using GraphQL.Common;
using GraphQL.Data.ConferencePlanner.GraphQL.Data;
using System.Security.Cryptography.X509Certificates;

namespace GraphQL.Speakers
{
    public class AddSpeakerPayload : SpeakerPayloadBase
    {
        public AddSpeakerPayload(Speaker speaker) 
            : base(speaker) { }

        public AddSpeakerPayload(IReadOnlyList<UserError> errors)
            : base(errors) { }
    }
}
