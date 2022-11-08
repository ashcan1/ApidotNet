using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    internal interface IEmployeeDAL
    {
        List<EmployeeModel> SelectAllEmployees();
    }
}
