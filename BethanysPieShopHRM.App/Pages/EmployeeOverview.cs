using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        public IEnumerable<Employee> Employees { get; set; }
        [Inject]
        public IEmployeeDataService _employeeDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await _employeeDataService.GetAllEmployees()).ToList();
        }
    }
}
