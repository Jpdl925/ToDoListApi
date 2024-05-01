using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ToDoListController(AppDbContext context){
            _context = context;
        }

        [HttpGet]
        // Get ToDoList
        public async Task<IEnumerable<ToDoList>>getList(){
            var list = await _context.ListItems.AsNoTracking().ToListAsync();
            return list;
        }

        

        











    
    }
}