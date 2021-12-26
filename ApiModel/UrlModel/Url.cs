using System;
using ApiModel.RequestDTO.UrlRequest;
using Dapper.Contrib.Extensions;

namespace ApiModel.UrlModel
{
    public class Url
    {
        [Key]
        public int idUrl { get; set; }
        public string url { get; set; }
        public string urlName { get; set; }
        public string urlDescription { get; set; }

        public Url Mapper(Url obj, UrlRequestDTO dto)
        {
            obj.idUrl = dto.idUrl;
            obj.url = dto.url;
            obj.urlName = dto.urlName;
            obj.urlDescription = dto.urlDescription;

            return obj;
        }
    }
}
