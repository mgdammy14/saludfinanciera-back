using System;
using System.Collections.Generic;
using ApiModel.Person;
using ApiModel.ResponseDTO.Person;
using ApiRepositories.General;

namespace ApiRepositories.Person
{
    public interface IPersonRepository : IRepository<ApiModel.Person.Person>
    {
        public List<PersonResponse> GetClientList();
        public int ChangePersonState(int idPerson, int idPersonState);
        public PersonResponse CheckPersonByDocumentNumber(string documentNumber);
        public Reference GetReference(int idPerson);
        public List<PersonResponse> GetClientsByIdLoan(int idLoan);
    }
}
