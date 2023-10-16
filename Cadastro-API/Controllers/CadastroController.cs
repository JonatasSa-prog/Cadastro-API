using Cadastro_API.Data;
using Cadastro_API.Models;
using Cadastro_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CadastroController : Controller
    {
        [HttpGet]
        [Route("person")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            try
            {
                var persons = await context.Persons.AsNoTracking().ToListAsync();
                if(persons == null)
                    return NotFound();
                return Ok(persons);      
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("person/id/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            try
            {
                var person = await context.Persons.Where(p => p.id == id).AsNoTracking().FirstOrDefaultAsync();
                if (person == null)
                    return NotFound();
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("person/name/{name}")]
        public async Task<IActionResult> GetByNameAsync([FromServices] AppDbContext context, [FromRoute] string name)
        {
            try
            {
                var person = await context.Persons.Where(p => p.name.ToUpper().Contains(name.ToUpper())).AsNoTracking().FirstOrDefaultAsync();
                if (person == null)
                    return NotFound();
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("person")]
        public async Task<IActionResult> SetAsync([FromServices] AppDbContext context, [FromBody] PersonViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var person = new Person()
                {
                    name = model.name,
                    birth = model.birth,
                    sex = model.sex
                };

                await context.Persons.AddAsync(person);
                await context.SaveChangesAsync();
                return Created($"v1/person/{person.id}", person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("person/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] PersonViewModel model, [FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var person = await context.Persons.FirstOrDefaultAsync(p => p.id == id);

                if (person == null)
                    return NotFound();

                person.name = model.name;
                person.birth = model.birth;
                person.sex = model.sex;

                context.Persons.Update(person);
                await context.SaveChangesAsync();
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("person/inactivate/{id}")]
        public async Task<IActionResult> PutInactivateAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var person = await context.Persons.FirstOrDefaultAsync(p => p.id == id);

                if (person == null)
                    return NotFound();

                person.active = false;

                context.Persons.Update(person);
                await context.SaveChangesAsync();
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("person/activate/{id}")]
        public async Task<IActionResult> PutActivateAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var person = await context.Persons.FirstOrDefaultAsync(p => p.id == id);

                if (person == null)
                    return NotFound();

                person.active = true;

                context.Persons.Update(person);
                await context.SaveChangesAsync();
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("person/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            try
            {
                var person = await context.Persons.FirstOrDefaultAsync(p => p.id == id);

                context.Persons.Remove(person);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
