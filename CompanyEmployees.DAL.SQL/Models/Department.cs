using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.DAL.SQL.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employee>Employees { get; set; }
    }
}
