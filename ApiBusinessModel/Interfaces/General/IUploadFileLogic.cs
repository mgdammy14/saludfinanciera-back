using System;
using Microsoft.AspNetCore.Http;

namespace ApiBusinessModel.Interfaces.General
{
    public interface IUploadFileLogic
    {
        public string UploadPdfToAzure(IFormFile file, string fileName);
        public string UploadImgToAzure(IFormFile file, string fileName);
    }
}
