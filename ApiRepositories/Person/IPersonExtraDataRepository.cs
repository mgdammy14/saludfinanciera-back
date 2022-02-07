using System;
using ApiModel.Person;
using ApiRepositories.General;

namespace ApiRepositories.Person
{
    public interface IPersonExtraDataRepository : IRepository<PersonExtraData>
    {
        public PersonExtraData GetPersonExtraDataByIdPerson(int idPerson);
    }
}
