using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.Client;
using ApiModel.ResponseDTO.Client;

namespace ApiBusinessModel.Interfaces.Client
{
    public interface IClientLogic
    {
        public ClientResponseDTO Insert(ClientRequestDTO dto);
        public ClientResponseDTO Update(ClientRequestDTO dto);
        public List<ClientResponseDTO> GetList();
        public int ChangeClientState(int idClient);
        public int AddToLoan(ClientLoanRequestDTO dto);
        public int AddToLoanList(List<ClientLoanRequestDTO> dtoList);
        public List<ApiModel.ClientModel.Client> GetClientByIdLoan(int idLoan);
        public string UploadSentinelPdf(UploadPdfRequestDTO dto);
        public int DeleteClientFromLoan(int idClient);
        public int CheckClientByDocumentNumber(string documentNumber);
    }
}
