using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Archiver.Models
{
    class FileCompressorLogic
    {
        public void CompressAll(List<string> filePaths, string targetPath)
        {
            foreach (string file in filePaths)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file) + ".gz";
                new Thread(() => Compress(file, targetPath + @"\" + fileNameWithoutExtension)).Start();
            }
        }

        public void Compress(string sourceFile, string compressedFile)
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open))
            {
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        OnCompressionStarted(sourceFile);
                        sourceStream.CopyTo(compressionStream);
                        OnCompressionFinished(sourceFile, sourceStream, targetStream);
                    }
                }
            }
        }

        public event CompressionStartedHandler CompressionStarted;
        public delegate void CompressionStartedHandler(string sourceFile);
        public void OnCompressionStarted(string sourceFile)
        {
            CompressionStarted?.Invoke(sourceFile);
        }

        public event CompressionFinishedHandler CompressionFinished;
        public delegate void CompressionFinishedHandler(string sourceFile, FileStream sourceStream, FileStream targetStream);
        public void OnCompressionFinished(string sourceFile, FileStream sourceStream, FileStream targetStream)
        {
            CompressionFinished?.Invoke(sourceFile, sourceStream, targetStream);
        }
    }
}
