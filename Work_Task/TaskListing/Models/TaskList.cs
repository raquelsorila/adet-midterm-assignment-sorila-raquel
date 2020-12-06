using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskListing.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public string TotalHours { get; set; }

        [DataType(DataType.Date)]

        public DateTime DateCreated { get; set; }

        public DateTime DateStarted { get; set; }
        
        public DateTime DateFinished { get; set; }
    }
}
