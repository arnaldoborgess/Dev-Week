using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using api_dev_week.src.Models;
using api_dev_week.src.Persistence;


namespace api_dev_week.src.Controllers
{
	[ApiController]
	[Route("controller")]
	public class PersonController : ControllerBase
	{
		private int id;

		private DatabaseContext	_context { get; set; }

		public PersonController(DatabaseContext context)
		{
			this._context = context;
		}

		[HttpGet]
		public ActionResult<List <Person>> Get()
		{
            //Person person = new Person("Arnaldo", 41, "12345678");
            //Contract newContract = new Contract("abc123", 50.56);
            //person.Contracts.Add(newContract);
            //return person;
			var result = _context.Persons.Include(p => p.Contracts).ToList();

			if(!result.Any()) return NoContent();

			return Ok(result);

		}

		[HttpPost]
		public ActionResult<Person> Post([FromBody]Person person)
		{
			try
			{
                _context.Persons.Add(person);
                object value = _context.SaveChanges();
            }
			catch (Exception)
			{
				return BadRequest();
			}

			

			return Created("created", person);
		}

		[HttpPut("{Id}")]
		public ActionResult<Object> Update
			([FromRoute]int Id, 
			[FromBody]Person person)
		{
            var result = _context.Persons.SingleOrDefault(e => e.Id == id);
			if(result is null)
			{
				return NotFound(
				new
				{
					msg = "Register not found",
					status = HttpStatusCode.NotFound
                }	
				);
			}
            //Console.WriteLine(Id);
            //Console.WriteLine(person);
            //return "Update " + Id + " Data";

            try
			{
				_context.Persons.Update(person);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				return BadRequest(new
                {
                    msg = $"There was an error sending authentication request {Id} updated",
                    status = HttpStatusCode.OK
                });
			}

            return Ok(new
			{
				msg = $"Id data {Id} updated",
				status = HttpStatusCode.OK
			}); 
        }

		[HttpDelete("{Id}")]

		public ActionResult<Object> Delete([FromRoute] int id)
		{
			var result = _context.Persons.SingleOrDefault(e => e.Id == id);

			if (result is null)
			{
				return BadRequest(new
				{
					msg = "Content missing, invalid request",
					status = HttpStatusCode.BadRequest
				});
			}
			_context.Persons.Remove(result);
			_context.SaveChanges();

			return Ok(new
			{
                msg = $"Deleted person Id {id}",
				status = HttpStatusCode.OK
            }); 

		}
	}
}
