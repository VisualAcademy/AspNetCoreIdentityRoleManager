using System.ComponentModel.DataAnnotations;

namespace VisualAcademy.Admin.Pages.Administrations.Roles
{
    public class IdentityRoleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "역할 이름을 입력하세요.")]
        public string RoleName { get; set; }
    }
}
