using System;
using ApiModel.Person;
using ApiRepositories.General;

namespace ApiRepositories.Person
{
    public interface ILaborDataRepository : IRepository<LaborData>
    {
        public LaborData GetLaborDataByIdPerson(int idPerson);
    }
}
