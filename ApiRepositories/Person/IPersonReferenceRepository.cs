using System;
using System.Collections.Generic;
using ApiModel.Person;
using ApiRepositories.General;

namespace ApiRepositories.Person
{
    public interface IPersonReferenceRepository : IRepository<PersonReference>
    {
        public List<PersonReference> GetPersonReference(int idPerson);
    }
}
