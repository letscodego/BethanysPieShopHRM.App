using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Componenets
{
    public partial class AddEmployeeDialog
    {
        public Employee Employee { get; set; } =
        new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };


        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public bool ShowDialog { get; set; }


        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        protected async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }

        public async Task Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        public async Task Show()
        {
            RestDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        private void RestDialog()
        {
            Employee = new Employee() { BirthDate = DateTime.Now, JoinedDate = DateTime.Now, CountryId = 1, JobCategoryId = 1 };
        }
    }
}
