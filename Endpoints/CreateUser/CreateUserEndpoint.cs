using TryFastEndpointsApp.Context;
using TryFastEndpointsApp.Entities;
using TryFastEndpointsApp.Mappers;
using TryFastEndpointsApp.Request;
using TryFastEndpointsApp.Response;

namespace TryFastEndpointsApp.Endpoints
{
    public class CreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse, CreateUserMapper>
    {
        public ApiContext Context { get; set; }
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/user/create");
            AllowAnonymous();
            Describe(b => b
            .Accepts<CreateUserRequest>("application/json")
            .Produces<CreateUserResponse>(200, "application/json")
            .Produces<object>(403)
            .ProducesProblem(500));

            Summary(s =>
            {
                s.Summary = "short summary goes here";
                s.Description = "long description goes here";
            });
        }

        public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
        {
            var userExists = Context.Users.Any(x => x.Email == req.Email);
            if (userExists)
                AddError(r => r.Email, "this email is already in use!");

            ThrowIfAnyErrors();

            var user = Map.ToEntity(req);

            Context.Users.Add(user);
            await Context.SaveChangesAsync(ct);

            await SendAsync(Map.FromEntity(user), cancellation: ct);
        }
    }
}