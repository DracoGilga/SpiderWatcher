namespace Entities.Poco
{
    public class Validation
    {
        public int ValidationId {  get; set; }
        public int UserId { get; set; }
        public string ValidationMessage { get; set; }
        public DateTime InitDateTime { get; set; }
        public bool Used { get; set; }
        public User User { get; set; }

    }
}
