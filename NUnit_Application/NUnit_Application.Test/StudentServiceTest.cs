using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnit_Application.Test
{    
    [TestFixture]
    public class StudentServiceTest
    {
        //Truyền các tham số vào nhiều test case để test các trường hợp
        //Result là kết quả mong muốn test case trả về (So sánh result và kết quả trả về của assert để ra kết quả của test case)
        [TestCase(29, Result = false)]
        [TestCase(0, Result = false)]
        [TestCase(60, Result = true)]
        [TestCase(80, Result = true)]

        public bool When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizeAsTrue(int age)
        {
            Student student = new Student();
            student.Age = age;

            bool result = student.IsSeniorCitizen();

            return result;
        }
    }

}
