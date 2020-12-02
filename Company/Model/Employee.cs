using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Model
{
    public class Employee
    {
        public  string Name { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public DateTime DateTime { get; set; }

        public static List<Employee> employees = new List<Employee>();

        public Employee(string name, Department department, Position position, DateTime dateTime)
        {
            Name = name;
            Department = department;
            Position = position;
            DateTime = dateTime;
        }

        public static void CreateNewEmployee(Department department, Position position)
        {
            try
            {
                Console.WriteLine("Введите имя");
                var name = Console.ReadLine();
                if (CheckIncorrectnessName(name) == true || string.IsNullOrWhiteSpace(department.ToString()) == true)
                {
                    throw new Exception("Введено некорректное имя");
                }
                else if (string.IsNullOrWhiteSpace(department.Name))
                {
                    throw new Exception("Введен некорректный отдел");
                }
                else if (string.IsNullOrWhiteSpace(department.Name))
                {
                    DateTime dateTime = DateTime.Now;
                    Employee employee = new Employee(name, department, position, dateTime);
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error occured: {ex.Message}");
            }
        }

        public void RiseEmployee()
        {
            Employee employee = this;
            employee = ++employee;
            employee.DateTime = DateTime.Now;
            employees.Add(employee);
        }

        public void DowngradeEmployee()
        {
            Employee employee = this;
            employee.DateTime = DateTime.Now;
            employee = --employee;
            employees.Add(employee);
        }

        public static void FindInHistory() 
        {
            try
            {
                Console.WriteLine("Введите имя работника");
                string name = Console.ReadLine();
                Console.WriteLine("Введите должность или отдел работника");
                string posOrDep = Console.ReadLine();
                foreach (Employee employee in employees)
                    if ( name != employee.Name)
                    {
                        throw new Exception("пользователь не найден");
                    }
                    else if (employee.Name == name && string.IsNullOrWhiteSpace(posOrDep) == true)
                    {
                        Console.WriteLine(employee);
                    }
                    else if (employee.Name == name && (employee.Position.Name == posOrDep || employee.Department.Name == posOrDep))
                    {
                        Console.WriteLine(employee);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error occured: {ex.Message}");
            }
        }

        public static void Compare(Employee employee1, Employee employee2)
        {
            if (employee1.Position.Salary > employee2.Position.Salary)
            {
                Console.WriteLine($"Должность у {employee1.Name} выше чем у {employee2.Name}");
            }
            else if (employee1.Position.Salary < employee2.Position.Salary)
            {
                Console.WriteLine($"Должность у {employee1.Name} ниже чем у {employee2.Name}");
            }
            else
            {
                Console.WriteLine($"Должность у {employee1.Name} такая же как у {employee2.Name}");
            }
        }

        public static void changeDepartment(Employee employee)
        {
            Department department = new Department(Console.ReadLine());
            employee.Department = department;
        }

        private static bool CheckIncorrectnessName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || IsNumberContains(name)) return true;

            else return false;
        }

        private static bool IsNumberContains(string name)
        {
            foreach (char c in name)
                if (Char.IsNumber(c))
                    return true;
            return false;
        }

        public static Employee operator ++(Employee employee)
        {
            string pos = employee.Position.Name;
            if (pos == "director")
            {
                Console.WriteLine("Повышать уже некуда");
                return employee;
            }
            else if (pos == "leader")
            {
                Console.WriteLine("Повышен до director");
                employee.Position = Position.Director;
                return employee;
            }
            else if (pos == "engineer")
            {
                Console.WriteLine("Повышен до leader");
                employee.Position = Position.Leader;
                return employee;
            }
            else
            {
                Console.WriteLine("Повышен до engineer");
                employee.Position = Position.Engineer;
                return employee;
            }
        }

        public static Employee operator --(Employee employee)
        {
            string pos = employee.Position.Name;
            if (pos == "director")
            {
                Console.WriteLine("Понижен до leader");
                employee.Position = Position.Leader;
                return employee;
            }
            else if (pos == "leader")
            {
                Console.WriteLine("Понижен до engineer");
                employee.Position = Position.Engineer;
                return employee;
            }
            else if (pos == "engineer")
            {
                Console.WriteLine("Повышен до handyman");
                employee.Position = Position.Handyman;
                return employee;
            }
            else
            {
                Console.WriteLine("Понижать уже некуда");
                return employee;
            }
        }

        public override string ToString()
        {
            return $"{Position} {Name} из {Department} с {DateTime}";
        }
    }
}
