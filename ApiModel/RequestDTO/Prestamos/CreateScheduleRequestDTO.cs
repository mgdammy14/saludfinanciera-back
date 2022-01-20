using System;
namespace ApiModel.RequestDTO.Prestamos
{
    public class CreateScheduleRequestDTO
    {
        public int idLoanAmount { get; set; }
        public DateTime startPaymentDate { get; set; }
    }
}
