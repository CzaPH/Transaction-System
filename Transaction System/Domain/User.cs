using System.ComponentModel.DataAnnotations;
using Transaction_System.Shared.Enum;

namespace Transaction_System.Domain
{
    public class User : Auditable
    {
       
        public string? Fullname { get; set; }
        public string? Picture { get; set; }
        public UserType UserType { get; set; }
        public UserCredential? UserCredential { get; set; }
    }
}
