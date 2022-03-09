using TryFastEndpointsApp.Context;
using TryFastEndpointsApp.Mappers;
using TryFastEndpointsApp.Request;
using TryFastEndpointsApp.Response;

namespace TryFastEndpointsApp.Endpoints
{
    public class GetUserEndpoint : Endpoint<GetUserRequest, GetUserResponse, GetUserMapper>
    {
        public ApiContext Context { get; set; }
        public override void Configure()
        {
            Get("/api/user/{Id}");
            AllowAnonymous();
            ResponseCache(60);

            Describe(b => b
                .Produces<object>(200, "application/json")
                .Produces<object>(403)
                .ProducesProblem(500));

            Summary(s =>
            {
                s.Summary = "Get User";
                s.Description = "This endpoint returns a user by Id";
            });
        }

        public override Task HandleAsync(GetUserRequest request, CancellationToken ct)
        {
            var user = Context.Users.FirstOrDefault(u => u.Id == request.Id);

            if (user == null)
                return SendNotFoundAsync(ct);

            return SendAsync(Map.FromEntity(user), cancellation: ct);
        }


    }
}