using System;
using System.Collections.Generic;
using ApiBusinessModel.Interfaces.Url;
using ApiModel.RequestDTO.UrlRequest;
using ApiModel.UrlModel;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation
{
    public class UrlLogic : IUrlLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public UrlLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Url> GetList()
        {
            try
            {
                return _unitOfWork.IUrl.GetList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int Insert(UrlRequestDTO dto)
        {
            try
            {
                Url obj = new Url();
                return _unitOfWork.IUrl.Insert(obj.Mapper(obj,dto));
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public bool Update(UrlRequestDTO dto)
        {
            try
            {
                Url obj = new Url();
                return _unitOfWork.IUrl.Update(obj.Mapper(obj, dto));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Delete(int idUrlRequest)
        {
            try
            {
                Url obj = new Url();
                obj.idUrl = idUrlRequest;
                return _unitOfWork.IUrl.Delete(obj);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
