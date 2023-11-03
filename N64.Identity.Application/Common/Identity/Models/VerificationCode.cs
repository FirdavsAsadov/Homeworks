using N64.Identity.Application.Common.Enums;

namespace N64.Identity.Application.Common.Identity.Models
{
    public class VerificationCode
    {
        public Guid Id {  get; set; }
        public Guid UserId { get; set; }
        public VerificationType Type { get; set; }
        public DateTimeOffset ExpiryTime { get; set; }
        public string? Code { get; set; }
    }
}
