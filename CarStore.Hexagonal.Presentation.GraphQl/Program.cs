using CarStore.Hexagonal.Application;
using CarStore.Hexagonal.Persistence.Postgres;
using CarStore.Hexagonal.Presentation.GraphQl.Mutations;
using CarStore.Hexagonal.Presentation.GraphQl.Queries;
using HotChocolate.AspNetCore;

namespace CarStore.Hexagonal.Presentation.GraphQl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddInfrastructureServices();
            builder.AddApplicationServices();

            builder.Services.AddGraphQLServer()
                .AddMutationType<Mutation>()
                .AddQueryType<Query>()
                    .AddType<UserQueries>()
                    .AddType<ListingQueries>()
                    .AddType<CarQueries>();

            builder.Services.Configure<GraphQLServerOptions>(options =>
            {
                options.Tool.Enable = false;
            });

            var app = builder.Build();

            app.MapGraphQL("/graphql");

            app.Run();
        }
    }
}
