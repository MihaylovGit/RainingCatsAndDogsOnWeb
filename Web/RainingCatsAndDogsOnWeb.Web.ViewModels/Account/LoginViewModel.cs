namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Users
{
    using Microsoft.AspNetCore.Authentication;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
