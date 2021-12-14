using BlazorInputFile;

namespace WebStore.Data
{
    public class FileListEntry : IFileListEntry
    {
        public DateTime LastModified => throw new NotImplementedException();

        public string Name => String.Empty;

        public long Size => Data.Length;

        public string Type => throw new NotImplementedException();

        public string RelativePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Stream Data { get; set; }

        public event EventHandler OnDataRead;

        public Task<IFileListEntry> ToImageFileAsync(string format, int maxWidth, int maxHeight)
        {
            throw new NotImplementedException();
        }
        public FileListEntry(byte[] data)
        {
            Data = new MemoryStream(data);
        }
    }
}
