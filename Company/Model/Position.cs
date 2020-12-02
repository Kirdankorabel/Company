using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Model
{
    public class Position
    {
        public string Name { get; }
        public int Salary { get; }

        public Position(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        static string director = "director";
        static string leader = "leader";
        static string engineer = "engineer";
        static string handyman = "handyman";

        public static Position Director = new Position(director, 50000);
        public static Position Leader = new Position(leader, 20000);
        public static Position Engineer = new Position(engineer, 10000);
        public static Position Handyman = new Position(handyman, 5000);

        public override string ToString()
        {
            return Name;
        }
    }
}
