using System;
using System.Collections.Generic;
using ApiBusinessModel.Interfaces.General;
using ApiBusinessModel.Interfaces.Users;
using ApiModel.RequestDTO;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Users
{
    public class UsersLogic : IUsersLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncryptLogic _encryptLogic;

        public UsersLogic(IUnitOfWork unitOfWork, IEncryptLogic encryptLogic)
        {
            _unitOfWork = unitOfWork;
            _encryptLogic = encryptLogic;
        }

        public IEnumerable<ApiModel.Users.Users> GetUsers()
        {
            try
            {
                return _unitOfWork.IUsers.GetList();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public int Insert(UsersRequestDTO dto)
        {
            try
            {
                ApiModel.Users.Users obj = new ApiModel.Users.Users();
                dto.password = _encryptLogic.Encrypt(dto.password);
                return _unitOfWork.IUsers.Insert(obj.Mapper(obj, dto));
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public bool Update(UsersRequestDTO dto)
        {
            try
            {
                ApiModel.Users.Users obj = new ApiModel.Users.Users();
                dto.password = _encryptLogic.Encrypt(dto.password);
                return _unitOfWork.IUsers.Update(obj.Mapper(obj, dto));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Delete(int idUserDeleted)
        {

            ApiModel.Users.Users obj = new ApiModel.Users.Users();
            obj.idUser = idUserDeleted;
            try
            {
                return _unitOfWork.IUsers.Delete(obj);
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
