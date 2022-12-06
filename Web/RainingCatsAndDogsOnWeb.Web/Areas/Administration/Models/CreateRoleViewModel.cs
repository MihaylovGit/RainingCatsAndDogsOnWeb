namespace RainingCatsAndDogsOnWeb.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
