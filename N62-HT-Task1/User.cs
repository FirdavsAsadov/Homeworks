using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace N62_HT_Task1
{
    public class User
    {
        public Guid Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
    }
}
