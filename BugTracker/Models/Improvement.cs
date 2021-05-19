using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Improvement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CurrentStatus { get; set; }
        public List<Status> Statuses { get; set; }
        public Improvement() 
        {
            Statuses = new List<Status>();
            //CurrentStatus = Statuses.ToArray()[0].Name;
        }
    }
    public class Status
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Improvement> Improvements { get; set; }
        public Status()
        {
            Improvements = new List<Improvement>();
        }
    }
}
