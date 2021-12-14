using System.Text;
using WebStore.Models;

namespace WebStore.Data
{
    public static class Extensions
    {
        public static async Task<string> ToImage64(this Stream selectedFileData)
        {
            StringBuilder base64 = new StringBuilder("data:png;base64,");
            using (Stream stream = selectedFileData)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    byte[] data = memoryStream.ToArray();
                    return data.ToImage64();
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
