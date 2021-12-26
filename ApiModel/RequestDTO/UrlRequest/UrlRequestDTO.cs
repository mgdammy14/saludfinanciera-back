using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.RequestDTO.UrlRequest
{
    public class UrlRequestDTO
    {
        [Key]
        public int idUrl { get; set; }
        public string url { get; set; }
        public string urlName { get; set; }
        public string urlDescription { get; set; }
    }
}
