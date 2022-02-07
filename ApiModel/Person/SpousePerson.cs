using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Person
{
    public class SpousePerson
    {
        [Key]
        public int idSpousePerson { get; set; }
        public int idClient { get; set; }
        public int idSpouse { get; set; }
    }
}
