using System;
using ApiBusinessModel.Interfaces.General;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace ApiBusinessModel.Implementation.General
{
    public class UploadFileLogic : IUploadFileLogic
    {
        CloudStorageAccount cloudStorageAccount =
               CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=sfblobupload;AccountKey=7R/AGG2w97d4KTlzh1Tp9WFgmKDLFteSUELHEgvBlhJ8DcOQ/nZrT3DqLOQ2jkDfgale++EVNip1cNU8dfQIiQ==;EndpointSuffix=core.windows.net");
        public UploadFileLogic()
        {
        }

        public string UploadImgToAzure(IFormFile file, string fileName)
        {
            var cloudBlobClient =
                cloudStorageAccount.CreateCloudBlobClient();

            var cloudBlobContainer =
                cloudBlobClient.GetContainerReference("imgcontainer");

            if (cloudBlobContainer.CreateIfNotExists())
            {
                cloudBlobContainer.SetPermissions(new
                    BlobContainerPermissions
                {
                    PublicAccess =
                    BlobContainerPublicAccessType.Off
                });
            }

            var cloudBlockBlob =
                cloudBlobContainer.GetBlockBlobReference(fileName);
            cloudBlockBlob.Properties.ContentType = file.ContentType;

            cloudBlockBlob.UploadFromStream(file.OpenReadStream());

            var res = cloudBlockBlob.Uri.ToString();

            return res;
        }

        public string UploadPdfToAzure(IFormFile file, string fileName)
        {
            var cloudBlobClient =
                cloudStorageAccount.CreateCloudBlobClient();

            var cloudBlobContainer =
                cloudBlobClient.GetContainerReference("pdfcontainer");

            if (cloudBlobContainer.CreateIfNotExists())
            {
                cloudBlobContainer.SetPermissions(new
                    BlobContainerPermissions
                {
                    PublicAccess =
                    BlobContainerPublicAccessType.Off
                });
            }

            var cloudBlockBlob =
                cloudBlobContainer.GetBlockBlobReference(fileName);
            cloudBlockBlob.Properties.ContentType = file.ContentType;

            cloudBlockBlob.UploadFromStream(file.OpenReadStream());

            var res = cloudBlockBlob.Uri.ToString();

            return res;
        }
    }
}
