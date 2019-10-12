using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG4.Models
{
    class StudentHistory
    {
        public string ID { get; set; }
        public string StudentID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string PlaceOfStudy { get; set; }

        public StudentHistory(string id, string studentID, DateTime dateStart, DateTime dateEnd, string placeOfStudy)
        {
            ID = id;
            StudentID = studentID;
            DateStart = dateStart;
            DateEnd = dateEnd;
            PlaceOfStudy = placeOfStudy;
        }
    }
}
