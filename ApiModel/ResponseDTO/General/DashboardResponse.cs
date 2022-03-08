using System;
using System.Collections.Generic;

namespace ApiModel.ResponseDTO.General
{
    public class DashboardResponse
    {
        public int userActive { get; set; }
        public int userInLoans { get; set; }
        public int userOutLoans { get; set; }
        public int userInactive { get; set; }
        public decimal amountDisbursed { get; set; }
        public List<UserSummary> userSummaries { get; set; }

        public class UserSummary
        {
            public int idMonth { get; set; }
            public string month { get; set; }
            public int quantity { get; set; }
        }
    }
}
