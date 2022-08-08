using Api.Ispit_Oblak_toni.Data;
using Api.Ispit_Oblak_toni.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Api.Ispit_Oblak_toni.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class APIController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public APIController(ApplicationDbContext db)
        {
            this.db = db;
        }

       
        [HttpGet]
        [Route("TodoLists")]
        [ProducesResponseType(typeof(List<ToDoList>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetItems()
        {
            var dbo = await db.ToDoList.ToListAsync();
            return Ok(dbo.Select(x => x).ToList());
        }
       

       
        [HttpGet]
        [Route("TodoLists/{id}")]
        [ProducesResponseType(typeof(ToDoList), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetItem(int id)
        {
            var dbo = await db.ToDoList.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(dbo);
        }
      

       
        [HttpPost]
        [Route("TodoLists")]
        [ProducesResponseType(typeof(ToDoList), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateItem(ToDoList item)
        {
            db.ToDoList.Add(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }
       

       
        [HttpPut]
        [Route("TodoLists/{id}")]
        [ProducesResponseType(typeof(ToDoList), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateItem(int id, ToDoList item)
        {
            var dbo = db.ToDoList.FirstOrDefault(x => x.Id == id);
            dbo.Title = item.Title; dbo.Description = item.Description; dbo.IsCompleted = item.IsCompleted;
            await db.SaveChangesAsync();
            return Ok(dbo);


        }
     

      
        [HttpDelete]
        [Route("TodoLists/{id}")]
        [ProducesResponseType(typeof(ToDoList), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var dbo = db.ToDoList.FirstOrDefault(x => x.Id == id);
            db.ToDoList.Remove(dbo);
            await db.SaveChangesAsync();
            return Ok(dbo);
        }
      

    }
}
