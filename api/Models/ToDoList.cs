using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ToDoList
    {
            public int Id { get; set; }

            public string? ListItem { get; set; }
            public string? ListDescription { get; set; }
            public bool? Completion { get; set; }


    }
}