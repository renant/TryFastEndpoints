using TryFastEndpointsApp.Entities;
using TryFastEndpointsApp.Response;

namespace TryFastEndpointsApp.Mappers
{
    public class GetUserMapper : Mapper<EmptyRequest, GetUserResponse, User>
    {
        public override GetUserResponse FromEntity(User e) => new()
        {
            Id = e.Id,
            Name = e.Name,
            Age = e.Age,
            Email = e.Email,
            IsOver18 = e.Age > 18
        };

    }
}