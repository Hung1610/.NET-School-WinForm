using AppG4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG4.Services
{
    class StudentService
    {
        /// <summary>
        /// Lấy 1 sinh viên có mã tương ứng idStudent
        /// </summary>
        /// <param name="idStudent"></param>
        /// <returns></returns>
        public static Student GetStudent(string idStudent)
        {
            var student = new Student
            {
                ID = idStudent,
                FirstName = "Zũng",
                LastName = "Micheal",
                Birthday = new DateTime(2002, 2, 22),
                Gender = GENDER.Male,
                PlaceOfBirth = "Bệnh Viện"
            };
            return student;
        }
    }
}
