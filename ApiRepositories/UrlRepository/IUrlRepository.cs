using System;
using System.Collections.Generic;
using ApiModel.UrlModel;
using ApiRepositories.General;

namespace ApiRepositories.UrlRepository
{
    public interface IUrlRepository : IRepository<Url>
    {
        public List<ApiModel.UrlModel.Url> GetUrlsByIdRol(int idRol);
    }
}
