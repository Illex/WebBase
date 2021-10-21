using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Student
    {
        //this is the university id
        public int ID { get; set; }
        public string uid { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string phoneNumber { get; set; }
        public string currentDegree { get; set; }
        public string currentProgram { get; set; }
        public float gpa { get; set; }
        public int numHours { get; set; }
        public string personalStatement { get; set; }
        //Native, Fluent, Adequate, Poor, None
        public char fluency { get; set; }
        public int completedSemesters { get; set; }
        public string linkedin { get; set; }
        public string resume { get; set; }
        public DateTime creationDate { get; set;}
        public DateTime modificatonDate { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}