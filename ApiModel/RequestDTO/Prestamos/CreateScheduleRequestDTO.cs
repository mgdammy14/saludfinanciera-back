using System;
namespace ApiModel.RequestDTO.Prestamos
{
    public class CreateScheduleRequestDTO
    {
        public int idGroupPayment { get; set; }
        public DateTime startPaymentDate { get; set; }
    }
}
