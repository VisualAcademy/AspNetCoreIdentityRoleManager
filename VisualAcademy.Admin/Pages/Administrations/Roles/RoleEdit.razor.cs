using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VisualAcademy.Admin.Pages.Administrations.Roles
{
    public partial class RoleEdit
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManagerRef { get; set; }

        [Inject]
        public RoleManager<IdentityRole> RoleManager { get; set; }

        public IdentityRoleViewModel ViewModel { get; set; } = new IdentityRoleViewModel();

        public List<string> ErrorMessages { get; set; } = new List<string>();

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private IdentityRole model = new IdentityRole();

        protected override async Task OnInitializedAsync()
        {
            model = await RoleManager.FindByIdAsync(Id);
            ViewModel.Id = model.Id;
            ViewModel.RoleName = model.Name;
        }

        public async Task HandleUpdate()
        {
            var role = await RoleManager.FindByIdAsync(Id);
            if (role != null)
            {
                role.Name = ViewModel.RoleName;

                IdentityResult identityResult = await RoleManager.UpdateAsync(role);
                if (identityResult.Succeeded)
                {
                    NavigationManagerRef.NavigateTo("/Administrations/Roles/RoleDetails/" + Id);
                }
                else
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ErrorMessages.Add(error.Description);
                    }
                }
            }
        }
    }
}
