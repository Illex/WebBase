using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class EnrollmentHist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //this is the course number
        public string EnrollmentHistID { get; set; }

        public string course { get; set; }

        public string date { get; set; }

        public int enrollments { get; set; }         
    }
}