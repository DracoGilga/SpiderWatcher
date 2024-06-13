namespace DTOs.UserDTO
{
    public class ReadUserDTO
    {
        public int IdUser { get; init; }
        public string Email { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }
        public DateOnly DateBirth { get; init; }
    }
}
