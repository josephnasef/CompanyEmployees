using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.DAL.SQL.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? EmployeeBirthDate { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? EmployeeHiringDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
