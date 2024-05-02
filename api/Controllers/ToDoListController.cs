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

        [HttpPost]
        // Add an item onto the ToDoList
        public async Task<IActionResult> Create(ToDoList Item){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            await _context.AddAsync(Item);

            var result = await _context.SaveChangesAsync();

            if(result > 0){
                return Ok("Item has been added to List");
            }
            return BadRequest("ERROR - Item has not been added");
        }

        [HttpDelete("{id:int}")]
        // Delete a single item from the ToDoList
        public async Task<IActionResult> Delete(int id){
            var item = await _context.ListItems.FindAsync(id);
            if(item == null){
                return NotFound("Item was not found");
            }

            _context.Remove(item);

            var result = await _context.SaveChangesAsync();

            if(result>0){
                return Ok("Item was removed from the List");
            }
            return BadRequest("Unable to remove item from List");
        }


        [HttpGet("{id:int}")]
        // Get a single item from the ToDoList
        public async Task<ActionResult<ToDoList>> GetItem(int id){
            var item = await _context.ListItems.FindAsync(id);
            if(item == null){
                return NotFound("Item was not found");
            }
            return Ok(item);
        }

        
        [HttpPut("{id:int}")]
        // Edit an existing item on the ToDoList
        public async Task<IActionResult> EditItem(int id, ToDoList item){
            var itemfromDb = await _context.ListItems.FindAsync(id);
            if(itemfromDb == null){
                return BadRequest("Item was not found");
            }
            itemfromDb.ListItem = item.ListItem;
            itemfromDb.ListDescription = item.ListDescription;
            itemfromDb.Completion = item.Completion;

            var result = await _context.SaveChangesAsync();

            if(result > 0){
                return Ok("Item was edited");
            }
            return BadRequest("Item was not updated");
        }
        

        











    
    }
}