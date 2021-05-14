using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class StatusModel
{
    public string State { get; set; }



    public List<SelectListItem> States { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "New", Text = "New" },
            new SelectListItem { Value = "In Progress", Text = "In Progress" },
            new SelectListItem { Value = "Done", Text = "Done"  },

       };
}