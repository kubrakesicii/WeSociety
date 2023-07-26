using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.FileHelper
{
    public static class FileHelper
    {
        public static async Task<byte[]> ConvertFileToByteArray(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
