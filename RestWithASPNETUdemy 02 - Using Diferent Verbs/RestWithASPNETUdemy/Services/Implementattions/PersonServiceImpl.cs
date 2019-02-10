using System;
using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementattions
{
    public class PersonServiceImpl : IPersonService
    {
        // Contador responsavel por gerar um fake ID já que não estamos
        // acessando nenhum banco de dados
        private volatile int count;

        // Metodo responsavel por criar uma nova pessoa
        // Se tivessemos um banco de dados esse seria o
        // momento de persistir os dados
        public Person Create(Person person)
        {
            return person;
        }

        // Metodo responsavel por deletar
        // uma pessoa a partir de um ID
        public void Delete(long id)
        {           
        }

        // Metodo responsavel por retornar todas as pessoas
        // mais uma vez essas informações são mocks
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }               

        // Metodo responsavel por retornar uma pessoa
        // como não acessamos nenhuma base de dados
        // estamos retornando um mock
        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Uberlandia - Minas Gerais - Brasil",
                Gender = "Male"
            };
        }

        public Person Upgrade(Person person)
        {
            return person;
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person Lastname " + i,
                Address = "Some Address " + i,
                Gender = "Male"
            };
        }
    }
}
