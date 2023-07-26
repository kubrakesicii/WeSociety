using Microsoft.AspNetCore.Http;

namespace WeSociety.Application.Helpers
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
