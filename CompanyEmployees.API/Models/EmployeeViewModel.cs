using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.API.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        public DateTime? EmployeeBirthDate { get; set; }
        public DateTime? EmployeeHiringDate { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
    }
}
