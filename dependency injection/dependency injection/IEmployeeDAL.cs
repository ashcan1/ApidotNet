﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    public interface IEmployeeDAL
    {
        List<EmployeeModel> SelectAllEmployees();
    }
}
