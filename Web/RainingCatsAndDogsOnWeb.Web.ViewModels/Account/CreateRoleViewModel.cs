namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Account
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
