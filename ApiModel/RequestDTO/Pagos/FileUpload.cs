using System;
using Microsoft.AspNetCore.Http;

namespace ApiModel.RequestDTO.Pagos
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
    }
}
