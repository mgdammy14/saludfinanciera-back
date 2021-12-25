using System;
namespace ApiBusinessModel.Interfaces.General
{
    public interface IEncryptLogic
    {
        public string Encrypt(string password);
        public string Decrypt(string base64EncodeData);
    }
}
