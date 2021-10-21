using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //this is the course number
        public string CourseID { get; set; }
        public string semesters { get; set; }
        public string title { get; set; }
        public int year{ get; set; }
        public string department{ get; set; }
        public string section { get; set; }
        public string description{ get; set; }
        public string professorUNID{ get; set; }
        public string professorName{ get; set; }
        public string ClassTimes{ get; set; }
        public string location{ get; set; }
        public int Credits { get; set; }
        public int numEnrollments { get; set; }
        public string notes{ get; set; }        

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}