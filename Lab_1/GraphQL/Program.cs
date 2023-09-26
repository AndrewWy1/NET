using GraphQL.Attendees;
using GraphQL.Data;
using GraphQL.DataLoader;
using GraphQL.Sessions;
using GraphQL.Speakers;
using GraphQL.Tracks;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=conferences.db"));
        builder.Services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<AttendeeQueries>()
                    .AddTypeExtension<SpeakerQueries>()
                    .AddTypeExtension<SessionQueries>()
                    .AddTypeExtension<TrackQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<AttendeeMutations>()
                    .AddTypeExtension<SessionMutations>()
                    .AddTypeExtension<SpeakerMutations>()
                    .AddTypeExtension<TrackMutations>()
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<AttendeeSubscriptions>()
                    .AddTypeExtension<SessionSubscriptions>()
                .AddType<AttendeeType>()
                .AddType<SessionType>()
                .AddType<SpeakerType>()
                .AddType<TrackType>()
                .EnableRelaySupport()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions()
                .AddDataLoader<SpeakerByIdDataLoader>()
                .AddDataLoader<SessionByIdDataLoader>();



        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseWebSockets();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
        });

        app.Run();
    }
}
