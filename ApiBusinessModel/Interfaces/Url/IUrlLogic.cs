using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.UrlRequest;

namespace ApiBusinessModel.Interfaces.Url
{
    public interface IUrlLogic
    {
        public IEnumerable<ApiModel.UrlModel.Url> GetList();
        public int Insert(UrlRequestDTO dto);
        public bool Update(UrlRequestDTO dto);
        public bool Delete(int idUrlRequest);
    }
}
