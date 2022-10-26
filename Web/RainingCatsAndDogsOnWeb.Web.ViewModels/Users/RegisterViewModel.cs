namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Users
{
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static RainingCatsAndDogsOnWeb.Common.DataConstants.ApplicationUser;

    public class RegisterViewModel : IMapFrom<ApplicationUser>
    {
        [Required]
        [StringLength(ApplicationUserFirstNameMaxLength, MinimumLength = ApplicationUserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ApplicationUserLastNameMaxLength, MinimumLength = ApplicationUserLastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(ApplicationUserPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
