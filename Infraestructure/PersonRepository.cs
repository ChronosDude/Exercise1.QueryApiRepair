using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        // retornar todos los valores
        public IEnumerable<Person> GetAll()
        {
            // origen, Método, iterador
            var query = _persons.Select(person => person);
            return query;
        }

        // retornar campos especificos

        public IEnumerable<Object> GetFields()
        {
            var query = _persons.Select(person=>new{
                NombreCompleto = $"{person.FirstName}{person.LastName}",
                AnioNacimiento = DateTime.Now.AddYears(person.Age * -1).Year,
                CorreoElectronico=person.Email
            });
            return query;
        }

        // retornar elementos que sean iguales
        public IEnumerable<Person> GetByGender(char genero)
        {
            var gender = genero;
            var query = _persons.Where(person => person.Gender == gender); 
            return query;
        }

        public IEnumerable<Person> GetMinusAge(int edad)
        {
            var age = edad;
            var query = _persons.Where(person => person.Age <= age); 
            return query;
        }
        // Retornar elementos que sean diferentes
        public IEnumerable<Person> GetDiference(int edad, char genero)
        {
            var age = edad;
            var gender =genero;
            var query = _persons.Where(person => person.Age <= age && person.Gender != gender); 
            return query;
        }

        public IEnumerable<string> GetJobs(int edad, char genero)
        {
            //from(origen) join(inersecciones) where (consultas) select (seleccion))
            var age = edad;
            var gender =genero;
            var query = _persons.Where(person=>person.Age<=age && person.Gender
            != gender).Select(person=>person.Job).Distinct();
            return query;
        }

        // retornar valores que contengan
        
        public IEnumerable<Person> GetStartWith(string inicial)
        {
            var start = inicial;
            var query = _persons.Where(x => x.Job.StartsWith(start));
            return query;
        }

        public IEnumerable<Person> GetContains(string letras)
        {
            var word = letras;
            var query = _persons.Where(x => x.FirstName.Contains(word));
            return query;
        }

        public IEnumerable<Person> GetByList(int l1, int l2, int l3)
        {
           var ages = new List<int>{l1,l2,l3};
           var query = _persons.Where(person=>ages.Contains(person.Age));
           return query; 
        }
        // retornar valores entre un rango
        
        // retornar elementos ordenados

        public IEnumerable<Person> GetOrdered(int edad)
        {
            var age = edad;
            var query = _persons.Where(person=>person.Age>age).
            OrderBy(person=>person.Age);
            return query;
        }

        public IEnumerable<Person> GetOrderedDesc(int miedad, int maedad)
        {
            var minAge = miedad;
            var maxAge = maedad;
            var query = _persons.Where(person=>person.Age>=minAge && person.Age < maxAge).
            OrderByDescending(person=>person.Age);
            return query;
        }

        //
        // Tarea: Averiguar como ordenar por más de una columna
        
        // retorno cantidad de elementos

        public int CountPerson(char genero)
        {
            var gender = genero;
            var query= _persons.Count(person => person.Gender == gender);
            return query;
        }
        
        // Evalua si un elemento existe

        public bool ExistPerson(string apellido)
        {
            var lastName=apellido;
            //Aleksandr
            var query = _persons.Exists(p=>p.LastName==lastName);
            return query;
        }

        public bool AnyPerson(string nombre)
        {
            //var lastName="Shemelt";
            var firstName=nombre;
            var query = _persons.Any(p=>p.FirstName==firstName);
            return query;
        }
        
        // retornar solo un elemento

        public Person GetFirst(int edad, string trabajo)
        {
            var age = edad;
            var job = trabajo;

            var query = _persons.FirstOrDefault(p=> p.Age == age && p.Job==job);

            return query; 
        }
        
        // retornar solamente unos elementos

        public IEnumerable<Person> TakePerson(string trabajo, int tomar)
        {
            var job = trabajo;
            var take = tomar;
            //var skip = 3;

            var query = _persons.Where(p=>p.Job==job).Take(take);

            return query;
        }

        public IEnumerable<Person> SkipPerson(string trabajo, int tomar, int saltar)
        {
            var job = trabajo;
            var take = tomar;
            var skip = saltar;

            var query = _persons.Where(p=>p.Job==job).Skip(skip).Take(take);

            return query;
        }
        
        // retornar elementos saltando posición
        
    }
}