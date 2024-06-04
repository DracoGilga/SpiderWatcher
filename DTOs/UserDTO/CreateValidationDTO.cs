namespace DTOs.UserDTO
{
    public class CreateValidationDTO
    {
        public int UserId { get; set; }
        public string ValidationMessage { get; set; }
        public DateTime InitDateTime { get; set; }
    }
}
