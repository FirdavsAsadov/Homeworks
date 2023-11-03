using N64.Identity.Application.Common.Enums;
using N64.Identity.Application.Common.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Application.Common.Identity.Service
{
    public interface IVerificationCodeGeneratorService
    {
        ValueTask<string> GenerateCode(VerificationType verificationType, Guid userId);
        (VerificationCode Token, bool IsValid) DecodeToken(string token);
    }
}
