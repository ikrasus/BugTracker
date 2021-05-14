using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        //public Status Status { get; set; }
        public string Description { get; set; }
    }
    //public class Status
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    public List<Bug> Bugs { get; set; }
    //    public Status()
    //    {
    //        Bugs = new List<Bug>();
    //    }
    //}
    
    
}
