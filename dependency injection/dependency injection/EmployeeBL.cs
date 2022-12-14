using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    public class EmployeeBL
    {
        //  public IEmployeeDAL employeeDAL;
        //public EmployeeBL(IEmployeeDAL employeeDAL)
        //{
        //    this.employeeDAL = employeeDAL;

        //}
     

        public List<EmployeeModel> GetAllEmployees()
        {
            var service = new EmployeeDAL();

            return service.SelectAllEmployees();
        }
    }
}
