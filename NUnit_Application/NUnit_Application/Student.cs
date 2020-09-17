using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnit_Application
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsSeniorCitizen()
        {
            if (Age >= 60)
            {
                return true;
            }
            return false;
        }
    }
}
