using System;
using System.Collections.Generic;
using ApiModel.General;
using ApiModel.RequestDTO.Client;
using ApiModel.RequestDTO.Person;
using ApiModel.ResponseDTO.Person;

namespace ApiBusinessModel.Interfaces.Person
{
    public interface IPersonLogic
    {
        public int InsertPerson(PersonFullRequestDTO dto);
        public List<ApiModel.Person.Person> GetList();
        public List<PersonResponse> GetClientList();
        public string CheckClientByDocumentNumber(string documentNumber);
        public PersonFullResponse GetFullInformation(int idPerson);
        public bool UpdatePerson(UpdatePersonFullRequestDTO dto);
        public int AddToLoanList(List<ClientLoanRequestDTO> dto);
        public int DeleteClientFromLoan(int idClient, int idLoan);
        public List<PersonResponse> GetClientByIdLoan(int idLoan);
        public string UploadSentinelPdf(UploadPdfRequestDTO dto);
        public List<HistoricalSentinelReport> GetHistoricalSentinelReportByIdPerson(int idPerson);
        public int ChangePersonState(int idPerson);
    }
}
