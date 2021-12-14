using System.Text;
using WebStore.Models;

namespace WebStore.Data
{
    public static class Extensions
    {
        public static async Task<byte[]> ToArray(this Stream selectedFileData)
        {
            using (Stream stream = selectedFileData)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }

        public static string ToImage64(this byte[] data)
        {
            StringBuilder base64 = new StringBuilder("data:png;base64,");
            base64.Append(Convert.ToBase64String(data));
            return base64.ToString();
        }
    }
}
