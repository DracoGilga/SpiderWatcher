namespace DTOs.UserDTO
{
    public class LoginUserDTO
    {
        public string UserName { get; init; }
        public string Password { get; init; }
        public bool Restore { get; init; }
        public bool Confirmation { get; init; }
    }
}
