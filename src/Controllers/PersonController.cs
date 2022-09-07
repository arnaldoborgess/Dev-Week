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
            Contract newContract = new Contract("abcd1234", 50.56);

            //person.Contracts.Add(newContract);

            return person;
        }
    }
}
