using System;
using Microsoft.AspNetCore.Http;

namespace ApiModel.RequestDTO.Client
{
    public class UploadPdfRequestDTO
    {
        public int idClient { get; set; }
        public IFormFile files { get; set; }
    }
}
