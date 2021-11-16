using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.API.Models
{
    public class EmployeePostViewModel
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeBirthDate { get; set; }
        public string EmployeeHiringDate { get; set; }
        public string DepartmentId { get; set; }
    }
}
