using System;
using ApiModel.RequestDTO.Client;
using Dapper.Contrib.Extensions;

namespace ApiModel.Person
{
    public class ClientLoan
    {
        [Key]
        public string clientLoan { get; set; }
        public int idClient { get; set; }
        public int idLoan { get; set; }
        public int idLoanAmount { get; set; }

        public ClientLoan Mapper(ClientLoan obj, ClientLoanRequestDTO dto)
        {
            obj.idClient = dto.idClient;
            obj.idLoan = dto.idLoan;
            obj.idLoanAmount = dto.idLoanAmount;
            return obj;
        }
    }
}
