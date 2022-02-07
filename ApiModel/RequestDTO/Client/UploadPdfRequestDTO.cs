using System;
using Microsoft.AspNetCore.Http;

namespace ApiModel.RequestDTO.Client
{
    public class UploadPdfRequestDTO
    {
        public int idPerson { get; set; }
        public IFormFile files { get; set; }
    }
}
