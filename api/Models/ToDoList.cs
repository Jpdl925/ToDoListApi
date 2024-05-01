using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ToDoList
    {
            [Key]
            public int ItemNumber { get; set; }

            public string? ListItem { get; set; }


    }
}