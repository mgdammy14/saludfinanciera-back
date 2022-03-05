using System;
namespace ApiModel.ResponseDTO.General
{
    public class DashboardResponse
    {
        public int userActive { get; set; }
        public int userInLoans { get; set; }
        public int userOutLoans { get; set; }
        public int userInactive { get; set; }
        public decimal amountDisbursed { get; set; }
    }
}
