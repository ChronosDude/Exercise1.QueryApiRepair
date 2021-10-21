using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repository = new PersonRepository();
            var persons = repository.GetAll();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Fields")]
        public IActionResult GetFields()
        {
            var repository = new PersonRepository();
            var persons = repository.GetFields();
            return Ok(persons);
        }

        [HttpGet]
        [Route("Genero/{genero}")]
        public IActionResult GetByGender(char genero)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByGender(genero);
            return Ok(persons);
        }

        [HttpGet]
        [Route("MinusAge/{edad}")]
        public IActionResult GetMinusAge(int edad)
        {
            var repository = new PersonRepository();
            var persons = repository.GetMinusAge(edad);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Diference")] //Ejemplo de solicitud /api/person/diference?edad=20&genero=M
        public IActionResult GetDiference(int edad, char genero)
        {
            var repository = new PersonRepository();
            var persons = repository.GetDiference(edad, genero);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Jobs")] //Ejemplo de solicitud /api/person/jobs?edad=20&genero=M
        public IActionResult GetJobs(int edad, char genero)
        {
            var repository = new PersonRepository();
            var persons = repository.GetJobs(edad, genero);
            return Ok(persons);
        }

        [HttpGet]
        [Route("IniciaCon={inicial}")]
        public IActionResult GetStartWith(string inicial)
        {
            var repository = new PersonRepository();
            var persons = repository.GetStartWith(inicial);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Contiene={letras}")]
        public IActionResult GetContains(string letras)
        {
            var repository = new PersonRepository();
            var persons = repository.GetContains(letras);
            return Ok(persons);
        }

        [HttpGet]
        [Route("ByList={l1},{l3},{l2}")] ///api/person/bylist=18,20,40 ejemplo, solo va a funcionar si los valores se separan con comas
        public IActionResult GetByList(string Edades)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByList(Edades);
            return Ok(persons);
        }
        
        [HttpGet]
        [Route("Ordered/{edad}")]
        public IActionResult GetOrdered(int edad)
        {
            var repository = new PersonRepository();
            var persons = repository.GetOrdered(edad);
            return Ok(persons);
        }

        [HttpGet]
        [Route("OrderedDesc/{miedad}/{maedad}")]
        public IActionResult GetOrderedDesc(int miedad, int maedad)
        {
            var repository = new PersonRepository();
            var persons = repository.GetOrderedDesc(miedad,maedad);
            return Ok(persons);
        }

        [HttpGet]
        [Route("CountPerson/{genero}")]
        public IActionResult CountPerson(char genero)
        {
            var repository = new PersonRepository();
            var persons = repository.CountPerson(genero);
            return Ok(persons);
        }

        [HttpGet]
        [Route("ExistPerson={apellido}")]
        public IActionResult ExistPerson(string apellido)
        {
            var repository = new PersonRepository();
            var persons = repository.ExistPerson(apellido);
            return Ok(persons);
        }

        [HttpGet]
        [Route("AnyPerson={nombre}")]
        public IActionResult AnyPerson(string nombre)
        {
            var repository = new PersonRepository();
            var persons = repository.AnyPerson(nombre);
            return Ok(persons);
        }

        [HttpGet]
        [Route("First/{edad}/{trabajo}")]
        public IActionResult GetFirst(int edad, string trabajo)
        {
            var repository = new PersonRepository();
            var persons = repository.GetFirst(edad, trabajo);
            return Ok(persons);
        }

        [HttpGet]
        [Route("TakePerson/{trabajo}/{tomar}")]
        public IActionResult TakePerson(string trabajo, int tomar)
        {
            var repository = new PersonRepository();
            var persons = repository.TakePerson(trabajo, tomar);
            return Ok(persons);
        }

        [HttpGet]
        [Route("SkipPerson")]
        public IActionResult SkipPerson(string trabajo, int tomar, int saltar)
        {
            var repository = new PersonRepository();
            var persons = repository.SkipPerson(trabajo, tomar, saltar);
            return Ok(persons);
        }
    }
}
