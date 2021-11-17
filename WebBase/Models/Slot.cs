using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Slot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //this is the course number
        public int ID { get; set; }

        public string day { get; set; }

        public int time { get; set; }       
    }
}