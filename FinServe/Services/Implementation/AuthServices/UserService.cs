using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FinServe.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public UserService(UserManager<User> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<KYCVerificationResult> RegisterUserAsync(UserRegistrationRequest request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                KYCStatus = "Pending", // Set default value
                RegistrationDate = DateTime.UtcNow // Set default registration date
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                // Handle errors (e.g., return an appropriate response)
                return new KYCVerificationResult { IsVerified = false };
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var verificationLink = $"https://yourapp.com/verify?userId={user.Id}&token={token}";

            await _emailService.SendVerificationEmailAsync(user.Email, verificationLink);

            // Implement KYC verification logic here
            var kycResult = await VerifyKYCAsync(user);

            return kycResult;
        }


        public async Task<KYCVerificationResult> VerifyKYCAsync(User user)
        {
            // Implement KYC verification logic here

            // For demonstration, assuming KYC is always successful
            return new KYCVerificationResult
            {
                UserId = user.Id.ToString(),  // Convert Guid to string
                Message = user.Email,
                VerificationDocument = user.KYCStatus,
                Success = true,
                VerificationDate = DateTime.UtcNow
            };
        }
    }
}
