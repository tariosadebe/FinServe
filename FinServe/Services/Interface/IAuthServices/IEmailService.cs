﻿public interface IEmailService
{
    Task SendVerificationEmailAsync(string email, string verificationLink);
}
