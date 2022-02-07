using System;
using ApiModel.Person;
using ApiRepositories.General;

namespace ApiRepositories.Person
{
    public interface ISpousePersonRepository : IRepository<SpousePerson> 
    {
        public SpousePerson GetSpousePerson(int idPerson);
    }
}
