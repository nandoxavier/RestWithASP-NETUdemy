using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/person/
     Por padrao o ASP.NET Core mapeia todas as classes que extendem Controller
     e expõe como endpoint REST
     */
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        //declaração do serviço usado
        private IPersonService _personService;

        // Injeção de uma instancia de IPersonService ao criar 
        // uma instancia de PersonController
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // Mapeia as requisições GET para http://localhost:{porta}/api/person/
        // get sem parametros para o FindAll --> Busca Todos
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Upgrade(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
