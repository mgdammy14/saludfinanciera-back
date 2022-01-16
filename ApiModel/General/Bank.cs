using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.General
{
    public class Bank
    {
        [Key]
        public int idBank { get; set; }
        public string bankName { get; set; }
        public string acronym { get; set; }
    }
}
