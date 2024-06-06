namespace DTOs.UserDTO
{
    public class UpdatePasswordUserDTO
    {
        public int IdUser { get; init; }
        public string Password { get; init; }
        public bool Restore { get; init; }

    }
}
