using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        public IEnumerable<Employee> Employees { get; set; }
        [Inject]
        public IEmployeeDataService _employeeDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        protected override async Task OnInitializedAsync()
        {
            Employee = await _employeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
        }
    }
}
