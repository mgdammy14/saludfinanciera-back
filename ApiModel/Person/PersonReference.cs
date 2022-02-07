using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Person
{
    public class PersonReference
    {
        [Key]
        public int idPersonReference { get; set; }
        public int idClient { get; set; }
        public int idReference { get; set; }
    }
}
