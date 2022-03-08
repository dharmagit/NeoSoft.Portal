using System.ComponentModel.DataAnnotations;

namespace NeoSoft.Portal.Model
{
    public class AuthenticateRequest
    {
        //[Required]
        public object Username { get; set; }

       // [Required]
        public object Password { get; set; }
    }

    public class AuthenticateTokenRequest
    {
        public object Email { get; set; }
        //[Required]
        public object Token { get; set; }

    }
    public class UserPassword
    {
        //[Required]
        public object UserId { get; set; }
        public object OldPassword { get; set; }
        public object NewPassword { get; set; }

    }
}