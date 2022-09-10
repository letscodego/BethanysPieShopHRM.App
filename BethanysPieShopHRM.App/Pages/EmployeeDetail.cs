using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.RazorClassLibrary.Map;
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

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        public Employee Employee { get; set; } = new Employee();

        protected override async Task OnInitializedAsync()
        {
            Employee = await _employeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            MapMarkers = new List<Marker>() 
            {
                new Marker { 
                    Description =$"{Employee.FirstName} {Employee.LastName}" , 
                    ShowPopup = false, 
                    X= Employee.Longitude, 
                    Y = Employee.Latitude 
                }
            };
        }
    }
}
