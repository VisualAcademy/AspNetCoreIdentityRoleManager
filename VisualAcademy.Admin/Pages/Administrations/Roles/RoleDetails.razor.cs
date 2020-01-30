using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace VisualAcademy.Admin.Pages.Administrations.Roles
{
    public partial class RoleDetails
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public RoleManager<IdentityRole> RoleManager { get; set; }

        [Inject]
        public NavigationManager NavigationManagerRef { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private IdentityRole model = new IdentityRole(); 

        protected override async Task OnInitializedAsync()
        {
            model = await RoleManager.FindByIdAsync(Id);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && model == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "잘못된 요청입니다.");
                NavigationManagerRef.NavigateTo("/Administrations/Roles");
            }
        }
    }
}
