using Company.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department1 = Department.CreateNewDepartment();
            Department department2 = Department.CreateNewDepartment();
            Department department3 = Department.CreateNewDepartment();

            Employee.CreateNewEmployee(department1, Position.Director);
            Employee.CreateNewEmployee(department2, Position.Engineer);
            Employee.CreateNewEmployee(department3, Position.Engineer);
            Employee.FindInHistory();

            Employee.GetSalary();

            //Department F1 = new Department("F1");
            //DateTime dateTime = DateTime.Now;
            //Employee employee = new Employee("vassa", F1, Position.Engineer, dateTime);

            //employee.RiseEmployee();
            //Console.WriteLine(employee.Position.Name);

            Console.Read();
        }
    }
}
