using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Application.Common.NotificationService
{
    public interface IEmailOrchestrationService
    {
        ValueTask<bool> SendAsync(string emailAddress, string message);
        ValueTask<bool> SendVerificationCodeAsync(string emailAddress, string message);
    }
}
