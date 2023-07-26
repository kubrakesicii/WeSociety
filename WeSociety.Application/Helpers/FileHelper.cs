using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace WeSociety.Application.Helpers
{
    public static class FileHelper
    {
        public static byte[] ConvertFileToByteArray(IFormFile file)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }

        public static string ConvertByteArrayToFile(byte[] bytes)
        {
            string fileContentBase64 = "data:image/png;base64,";
            fileContentBase64 += Convert.ToBase64String(bytes);
            return fileContentBase64;
        }
    }
}
