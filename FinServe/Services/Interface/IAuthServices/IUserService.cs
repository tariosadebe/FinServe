using System.Threading.Tasks;

public interface IUserService
{
    Task<KYCVerificationResult> RegisterUserAsync(UserRegistrationRequest request);
    Task<KYCVerificationResult> VerifyKYCAsync(User user);
}
