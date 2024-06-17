namespace DTOs.UserDTO
{
    public class UpdatePasswordUserDTO
    {
        public string Password { get; init; }
        public string ValidationMessage { get; set; }
        public string Email { get; init; }
    }
}
