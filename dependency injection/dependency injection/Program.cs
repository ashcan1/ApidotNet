using dependency_injection;

EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());List<EmployeeModel> ListEmployee = employeeBL.GetAllEmployees();
foreach (EmployeeModel emp in ListEmployee)
{
    Console.WriteLine("ID = {0}, Name = {1}, Department = {2}", emp.ID, emp.Name, emp.Department);
}
Console.ReadKey();
