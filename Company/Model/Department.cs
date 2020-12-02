using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Model
{
    public class Department
    {
        public string Name { get; set; } // не могу прописать статичность 

        public Department(string name)
        {
            Name = name;
        }

        public static Department CreateNewDepartment() 
        {
            try
            {
                Console.WriteLine("Введите название отдела");
                string name = Console.ReadLine();

                if (CheckDepartmentName(name) == false)
                {
                    throw new Exception("Название отдела должно содержать букву и цифру");
                }
                Department department = new Department(name);
                return department;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error occured: {ex.Message}");
                Department department = new Department(null);
                return department;
            }
            //string name = Console.ReadLine();
            //if (CheckDepartmentName(name) == true)
            //{
            //    Department department = new Department(name);
            //    return department;
            //}
            //else
            //{
            //    throw new Exception("Название отдела должно содержать букву и цифру");
            //    Department department = new Department(null);
            //    return department;
            //}
        }

        public static bool CheckDepartmentName(string name)
        {

            if (IsNumberContains(name) == true && IsCharContains(name) == true)
            {
                return true;
            }
            else
            {                
                return false;
            }
        }


        private static bool IsNumberContains(string name)
        {
            foreach (char c in name)
                if (Char.IsNumber(c))
                    return true;
            return false;
        }

        private static bool IsCharContains(string name)
        {
            foreach (char c in name)
                if (Char.IsLetter(c))
                    return true;
            return false;
        }
    }
}
