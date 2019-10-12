using AppG4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG4.Services
{
    class StudentHistoryService
    {
        /// <summary>
        /// Lấy 1 sinh viên có mã tương ứng idStudent
        /// </summary>
        /// <param name="idStudent"></param>
        /// <returns></returns>
        public static List<StudentHistory> GetStudentHistory(string idStudent)
        {
            var historyList = new List<StudentHistory>();
            historyList.Add(new StudentHistory("1", idStudent, new DateTime(2013, 1, 1), new DateTime(2016, 1, 1), "THPT QH Huế"));
            historyList.Add(new StudentHistory("2", idStudent, new DateTime(2015, 1, 1), new DateTime(2020, 1, 1), "ĐHKH Huế"));
            return historyList;
        }
    }
}
