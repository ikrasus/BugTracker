using System.Collections.Generic;
using System.Linq;
using BugTracker.Models;

namespace BugTracker
{
    public static class SampleInit
    {
        public static void Initialize(BugsContext context)
        {
            if (!context.Improvements.Any() || !context.Statuses.Any())
            {
                Status st = new Status { Name = "New" };
                Status st2 = new Status { Name = "Process" };
                Status st3 = new Status { Name = "Solved" };

                context.Statuses.AddRange(st, st2, st3);
                context.SaveChanges();

                Improvement imp = new Improvement { Name = "TestSolveTask", Description = "testing"};
                imp.Statuses.Add(st);
                imp.Statuses.Add(st3);
                imp.CurrentStatus = st.Name;
                Improvement imp2 = new Improvement { Name = "SecondTestSolveTask", Description = "testing2" };
                imp2.Statuses.Add(st);
                imp2.Statuses.Add(st2);
                imp2.Statuses.Add(st3);
                imp2.CurrentStatus = st.Name;
                context.Improvements.AddRange(imp, imp2);
                context.SaveChanges();
            }
        }
    }
}