namespace DTOs.UserDTO
{
    public class ResultLoginUserDTO
    {
        public int IdUser { get; init; }
        public bool Restore { get; init; }
        public bool Confirmation { get; init; }
        public bool AccountType { get; init; }
    }
}