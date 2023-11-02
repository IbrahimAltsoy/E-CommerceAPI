using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using E_CommerceAPI.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace E_CommerceAPI.Infrastructure.Services.Stroage.Azure
{
    public class AzureStorage :Storage,IAzureStorage
    {
        readonly BlobServiceClient _blogServiceClient;
        BlobContainerClient _blobContainerClient;

        public AzureStorage(IConfiguration configuration)
        {
            _blogServiceClient = new(configuration["Storage:Azure"]);
           
        }

        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blogServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient=  _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();

        }

        public List<string> GetFiles(string containerName)
        {
           _blobContainerClient = _blogServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(x => x.Name).ToList();  
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blogServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(x => x.Name == fileName);
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            _blobContainerClient = _blogServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            //await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            // yukardaki kod satırını kaldırdığımda çalıştı yoksa çalışmıyor
            List<(string fileName, string pathOrContainerName)> datas = new();
            foreach (IFormFile file in files)
            {
              string fileNewName= await FileRenameAsync(containerName, file.Name, HasFile);
                BlobClient _blogClient = _blobContainerClient.GetBlobClient(fileNewName);
                await _blogClient.UploadAsync(file.OpenReadStream());
                datas.Add((fileNewName, containerName));

            }
            return datas;
        }
    }
}
