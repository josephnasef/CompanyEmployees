using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.API.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int TotalOfEmployee { get; set; }
    }
}
