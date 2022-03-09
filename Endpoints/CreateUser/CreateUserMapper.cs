using TryFastEndpointsApp.Entities;
using TryFastEndpointsApp.Request;
using TryFastEndpointsApp.Response;

namespace TryFastEndpointsApp.Mappers
{
    public class CreateUserMapper : Mapper<CreateUserRequest, CreateUserResponse, User>
    {
        public override CreateUserResponse FromEntity(User e) => new()
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email,
            Age = e.Age,
            IsOver18 = e.Age > 18
        };

        public override User ToEntity(CreateUserRequest r) => new()
        {
            Id = Guid.NewGuid(),
            Name = r.Name,
            Email = r.Email,
            Age = r.Age
        };
    }
}