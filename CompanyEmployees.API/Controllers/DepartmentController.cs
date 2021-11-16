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
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentManger _departmentManger;
        public DepartmentController()
        {
            this._departmentManger = new DepartmentManger();
        }
        // GET: api/
        [HttpGet]
        public IEnumerable<DepartmentViewModel> Get()
        {
            List<DepartmentViewModel> DepartmentList = new List<DepartmentViewModel>();
            DepartmentList = _departmentManger.GetAll().Select(x => new DepartmentViewModel
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                TotalOfEmployee = x.Employees.Count()
            }).ToList();
            return DepartmentList;
        }

        // GET api/Department/5
        [HttpGet("{id}")]
        public IActionResult Get(int DepartmentId)
        {
            try
            {
                DepartmentViewModel objDep = new DepartmentViewModel();
                int ID = Convert.ToInt32(DepartmentId);
                try
                {
                    objDep = _departmentManger.GetAll().Select(x => new DepartmentViewModel
                    {
                        DepartmentId = x.DepartmentId,
                        DepartmentName=x.DepartmentName,
                        TotalOfEmployee=x.Employees.Count()
                    }).ToList().Where(x => x.DepartmentId == ID).First();
                    if (objDep == null)
                    {
                        return NotFound();
                    }
                    return Ok(objDep);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/Department
        [HttpPost]
        public IActionResult Post([FromBody] DepartmentPostViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    Department department = new Department() { 
                    DepartmentId=Convert.ToInt32(model.DepartmentId),
                    DepartmentName = model.DepartmentName
                    };
                    _departmentManger.Add(department);
                }
                catch (Exception)
                {

                    throw;
                }
                return Ok(model);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

        // PUT api/Department/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] DepartmentPostViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                try
                {
                    Department department = new Department() {
                    DepartmentName=model.DepartmentName,
                    DepartmentId=Convert.ToInt32( model.DepartmentId)                    
                    };
                    _departmentManger.Update(department);

                }
                catch (Exception)
                {

                    throw;
                }
                return Ok(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/Department/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                int ID = Convert.ToInt32(id);
                Department department = _departmentManger.GetBy(ID);
                if (department == null)
                {
                    return NotFound();
                }
                _departmentManger.Delete(department);
                return Ok(department);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
