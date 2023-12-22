namespace Innoplatform.Service.DTOs.Registrations.UserRegistrations
{
    public class UserRegistrationForResultDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
