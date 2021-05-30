using Archiver.Controllers;
using System.Collections.Generic;
using System.IO;

namespace Archiver.Models
{
    public class BaseModel
    {
        public event PropertyChangedHandler PropertyChanged;
        public delegate void PropertyChangedHandler(string property);
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(property);
        }

        public event PreparedFilesChangedHandler PreparedFilesChanged;
        public delegate void PreparedFilesChangedHandler(List<string> preparedFiles);
        public void OnPreparedFilesChanged(List<string> preparedFiles)
        {
            PreparedFilesChanged?.Invoke(preparedFiles);
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
