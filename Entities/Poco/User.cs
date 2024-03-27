namespace Entities.Poco
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool AccountType { get; set; }
        public DateOnly DateBirth { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Restore { get; set; }
        public bool Confirmation { get; set; }
    }
}
