using Microsoft.AspNetCore.Mvc;
using api_dev_week.src.Models;

namespace api_dev_week.src.Controllers
{
    [ApiController]
    [Route("controller")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public Person Get()
        {
            Person person = new Person("Arnaldo", 41, "12345678");
            Contract newContract = new Contract("abc123", 50.56);

            person.Contracts.Add(newContract);
            person.Contracts.Add(newContract);
            person.Contracts.Add(newContract);

            return person;
        }

        [HttpPost]
        public Person Post([FromBody]Person person)
        {
            return person;
        }
        [HttpPut("{Id}")]
        public string Update([FromRoute]int Id, [FromBody]Person person)
        {
            Console.WriteLine(Id);
            Console.WriteLine(person);

            return "Update " + Id + " Data";
        }

        [HttpDelete("{Id}")]
        public string Delete([FromRoute]int Id)
        {
            return "Deleted person Id " + Id;
        }
    }
}
