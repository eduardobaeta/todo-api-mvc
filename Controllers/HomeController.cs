using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data.Context;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Get([FromServices] DatabaseContext context)
        {
            return Ok(await context.TodoModels.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        [Route("/{id:int}")]
        public async Task<IActionResult> GetById([FromServices] DatabaseContext context, [FromRoute] int id)
        {
            var todo = await context.TodoModels.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                NotFound();
            return Ok(todo);
        }

        [HttpPost]
        [Route("/")]
        public async Task<IActionResult> Post([FromServices] DatabaseContext context, [FromBody] TodoModel model)
        {
            var todo = model;
            todo.CreatedAt = DateTime.Now;
            await context.TodoModels.AddAsync(model);
            await context.SaveChangesAsync();

            return Created($"{todo.Id}", todo);
        }

        [HttpPut]
        [Route("/{id:int}")]
        public async Task<IActionResult> Update([FromServices] DatabaseContext context, [FromBody] TodoModel model, [FromRoute] int id)
        {
            var todo = context.TodoModels.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                NotFound();

            todo.Title = model.Title;
            todo.Done = model.Done;

            context.Update(todo);
            await context.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpDelete]
        [Route("/{id:int}")]
        public async Task<ActionResult> Delete([FromServices] DatabaseContext context, [FromRoute] int id)
        {
            var model = await context.TodoModels.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
                NotFound();

            context.TodoModels.Remove(model);
            await context.SaveChangesAsync();

            return Ok(model);
        }

    }
}