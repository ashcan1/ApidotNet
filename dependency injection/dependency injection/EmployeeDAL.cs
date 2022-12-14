using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public List<EmployeeModel> SelectAllEmployees()
        {
            List<EmployeeModel> ListEmployees = new List<EmployeeModel>();
            //Get the Employees from the Database
            //for now we are hard coded the employees
            ListEmployees.Add(new EmployeeModel() { ID = 1, Name = "Pranaya", Department = "IT" });
            ListEmployees.Add(new EmployeeModel() { ID = 2, Name = "Kumar", Department = "HR" });
            ListEmployees.Add(new EmployeeModel() { ID = 3, Name = "Rout", Department = "Payroll" });
            return ListEmployees;
        }

    }
}
