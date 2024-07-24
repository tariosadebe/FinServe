using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<Guid>
{
    public string KYCStatus { get; set; } = "Pending"; // e.g., Pending, Verified
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
}
