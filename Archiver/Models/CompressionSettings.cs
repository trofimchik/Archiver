using System;

namespace Archiver.Models
{
    public class CompressionSettings
    {
        public string SourceFilesPath { get; set; }
        public string CompressedFilesPath { get; set; }
        public DateTime FinalDate { get; set; }

        //private string sourceFilesPath;
        //public string SourceFilesPath 
        //{
        //    get
        //    {
        //        return sourceFilesPath;
        //    }
        //    set
        //    {
        //        sourceFilesPath = value;
        //        OnPropertyChanged(sourceFilesPath);
        //    } 
        //}
        //private string compressedFilesPath;
        //public string CompressedFilesPath 
        //{
        //    get
        //    {
        //        return compressedFilesPath;
        //    }
        //    set
        //    {
        //        compressedFilesPath = value;
        //        OnPropertyChanged(compressedFilesPath);
        //        Console.WriteLine("nflf");
        //    }
        //}
        //private DateTime finalDate;
        //public DateTime FinalDate {
        //    get
        //    {
        //        return finalDate;
        //    }
        //    set
        //    {
        //        finalDate = value;
        //        OnPropertyChanged(Convert.ToString(finalDate));
        //    }
        //}
        
        public event PropertiesSetHandler PropertiesSet;
        public delegate void PropertiesSetHandler(string sourceFilesPath, string compressedFilesPath, DateTime finalDate);
        public void OnPropertiesSet()
        {
            PropertiesSet?.Invoke(SourceFilesPath, CompressedFilesPath, FinalDate);
        }
    }
}
