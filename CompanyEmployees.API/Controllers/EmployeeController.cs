using CompanyEmployees.API.Models;
using CompanyEmployees.BAL.Mangers;
using CompanyEmployees.DAL.SQL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CompanyEmployees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        
        private readonly EmployeeManger _employeeManger;
        public EmployeeController()
        {
            _employeeManger = new EmployeeManger();
        }
        [HttpGet]
        // GET: api/Employee
        public IActionResult Get()
        {
            try
            {
                var EmployeeList = _employeeManger.GetAll()
                    .Select(x =>
                    new EmployeeViewModel
                    {
                        EmployeeId = x.EmployeeId,
                        EmployeeName = x.EmployeeName,
                        EmployeeTitle = x.EmployeeTitle,
                        EmployeeBirthDate = x.EmployeeBirthDate,
                        EmployeeHiringDate = x.EmployeeHiringDate,
                        DepartmentName = x.Department.DepartmentName
                    }).ToList();
                
                return Ok(EmployeeList);
            }
            catch (Exception)
            {
                throw;
            }
        }


        // GET api/Employee/5
        [HttpGet("{id}")]
        public IActionResult Get(string employeeId)
        {
            try
            {

                EmployeeViewModel objEmp = new EmployeeViewModel();
                int ID = Convert.ToInt32(employeeId);
                try
                {
                    objEmp = _employeeManger.GetAll().Select(x=> new EmployeeViewModel { 
                        EmployeeId = x.EmployeeId,
                        EmployeeName = x.EmployeeName,
                        EmployeeTitle = x.EmployeeTitle,
                        EmployeeBirthDate = x.EmployeeBirthDate,
                        EmployeeHiringDate = x.EmployeeHiringDate,
                        DepartmentId = x.DepartmentId,
                        DepartmentName = x.Department.DepartmentName}).ToList().Where(x=>x.EmployeeId== ID).First();
                    if (objEmp == null)
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(objEmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] EmployeePostViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    Employee employeeModel = new Employee();
                    if (!string.IsNullOrEmpty(model.EmployeeBirthDate)&&!string.IsNullOrWhiteSpace(model.EmployeeBirthDate))
                    {
                        DateTime? Bdate = Convert.ToDateTime(model.EmployeeBirthDate);
                        employeeModel.EmployeeBirthDate = Bdate.HasValue ? Bdate.Value.AddDays(1) : (DateTime?)null;

                    }
                    else
                    {
                        employeeModel.EmployeeBirthDate = null;
                    }
                    if (!string.IsNullOrEmpty(model.EmployeeHiringDate) && !string.IsNullOrWhiteSpace(model.EmployeeHiringDate))
                    {
                        DateTime? Hdate = Convert.ToDateTime(model.EmployeeHiringDate);
                        employeeModel.EmployeeHiringDate = Hdate.HasValue ? Hdate.Value.AddDays(1) : (DateTime?)null;

                    }
                    else
                    {
                        employeeModel.EmployeeHiringDate = null;
                    }
                    employeeModel.EmployeeName = model.EmployeeName;
                    employeeModel.EmployeeTitle = model.EmployeeTitle;
                    employeeModel.DepartmentId = Convert.ToInt32( model.DepartmentId);
                    //employeeModel.DepartmentId = 1;

                    _employeeManger.Add(employeeModel);
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }


        // PUT api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] EmployeePostViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    Employee employeeModel = new Employee();
                    employeeModel = _employeeManger.GetBy(Convert.ToInt32( model.EmployeeId));
                    if (!string.IsNullOrEmpty(model.EmployeeBirthDate) && !string.IsNullOrWhiteSpace(model.EmployeeBirthDate))
                    {
                        DateTime? Bdate = Convert.ToDateTime(model.EmployeeBirthDate);
                        employeeModel.EmployeeBirthDate = Bdate.HasValue ? Bdate.Value.AddDays(1) : (DateTime?)null;

                    }
                    else
                    {
                        employeeModel.EmployeeBirthDate = null;
                    }
                    if (!string.IsNullOrEmpty(model.EmployeeHiringDate) && !string.IsNullOrWhiteSpace(model.EmployeeHiringDate))
                    {
                        DateTime? Hdate = Convert.ToDateTime(model.EmployeeHiringDate);
                        employeeModel.EmployeeHiringDate = Hdate.HasValue ? Hdate.Value.AddDays(1) : (DateTime?)null;

                    }
                    if (employeeModel != null)
                    {
                        employeeModel.EmployeeName = model.EmployeeName;
                        employeeModel.EmployeeTitle = model.EmployeeTitle;
                        employeeModel.DepartmentId = Convert.ToInt32(model.DepartmentId);
                        employeeModel.EmployeeBirthDate = employeeModel.EmployeeBirthDate.HasValue ? employeeModel.EmployeeBirthDate.Value.AddDays(1) : (DateTime?)null;
                        employeeModel.EmployeeHiringDate = employeeModel.EmployeeHiringDate.HasValue ? employeeModel.EmployeeHiringDate.Value.AddDays(1) : (DateTime?)null;
                    }
                    _employeeManger.Update(employeeModel);
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeDetails(string id)
        {
            try
            {
                int ID = Convert.ToInt32(id);
                Employee emaployee = _employeeManger.GetBy(ID);
                if (emaployee == null)
                {
                    return NotFound();
                }
                _employeeManger.Delete(emaployee);                
                return Ok(emaployee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
