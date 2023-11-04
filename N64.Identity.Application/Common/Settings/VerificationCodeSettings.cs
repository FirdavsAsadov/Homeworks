namespace N64.Identity.Application.Common.Settings
{
    public class VerificationCodeSettings
    {
        public string IdentityVerificationCodePurpose { get; set; } = default!;
        public int IdentityVerificationCodeExpirationDurationInMinutes { get; set; } = default!;

        public string VerificationServiceType { get; set; } = default!;
    }
}
