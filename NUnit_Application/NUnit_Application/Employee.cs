using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnit_Application
{
    public class Employee
    {
        public string Name { get; set; }

        public bool ContainsIllegalChars()
        {
            if (this.Name.Contains("$"))
            {
                return true;
            }
            return false;
        }
    }

    public class Manager : Employee { }

    public class DeliveryManager : Employee { }
}
