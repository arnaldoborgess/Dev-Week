using Microsoft.AspNetCore.Mvc;
using api_dev_week.src.Models;
using api_dev_week.src.Persistence;
using Microsoft.EntityFrameworkCore;

namespace api_dev_week.src.Controllers
{
	[ApiController]
	[Route("controller")]
	public class PersonController : ControllerBase
	{
		private DatabaseContext	_context { get; set; }

		public PersonController(DatabaseContext context)
		{
			this._context = context;
		}

		[HttpGet]
		public List <Person> Get()
		{
            //Person person = new Person("Arnaldo", 41, "12345678");
            //Contract newContract = new Contract("abc123", 50.56);

            //person.Contracts.Add(newContract);
            //return person;

            return _context.Persons.Include(p => p.Contracts).ToList();

		}

		[HttpPost]
		public Person Post([FromBody]Person person)
		{
			_context.Persons.Add(person);
			_context.SaveChanges();

			return person;
		}

		[HttpPut("{Id}")]
		public string Update([FromRoute]int Id, [FromBody]Person person)
		{
			//Console.WriteLine(Id);
			//Console.WriteLine(person);
			//return "Update " + Id + " Data";

			_context.Persons.Update(person);
			_context.SaveChanges();

            return "Update " + Id + " Data";
        }

		[HttpDelete("{Id}")]
		public string Delete([FromRoute]int Id)
		{
			return "Deleted person Id " + Id;
		}
	}
}
