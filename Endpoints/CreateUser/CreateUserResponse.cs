namespace TryFastEndpointsApp.Response
{
    public class CreateUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public bool IsOver18 { get; set; }
    }
}