using E_CommerceAPI.Application.Abstractions.Storage;
using E_CommerceAPI.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace E_CommerceAPI.Infrastructure.Services.Stroage.Local
{
    public class LocalStroage :Storage, ILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStroage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task DeleteAsync(string pathOrContainerName, string fileName)
            => File.Delete($"{pathOrContainerName}\\{fileName}");
        

      public  List<string> GetFiles(string pathOrContainerName)
        {
            DirectoryInfo directory = new(pathOrContainerName);
            return directory.GetFiles().Select(p=>p.Name).ToList();

        }

       public bool HasFile(string pathOrContainerName, string fileName)
            => File.Exists($"{pathOrContainerName}\\{fileName}");

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainer, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, pathOrContainer);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            List<bool> results = new();
            foreach (IFormFile file in files)
            {
                //string fileNewName = await FileRenameAsync(uploadPath, file.FileName);
                string fileNewName = await FileRenameAsync(pathOrContainer, file.Name, HasFile);

                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{pathOrContainer}\\{fileNewName}"));             
            }

            
            return datas;
        }
        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }
    }
}
