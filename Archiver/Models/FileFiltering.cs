using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Archiver.Helpers;

namespace Archiver.Models
{
    /// <summary>
    /// This class filters out files older than the specified date.
    /// </summary>
    public static class FileFiltering
    {
        public static PreparedFiles GetPreparedFilesList(CompressionSettings settings)
        {
            PreparedFiles files = new PreparedFiles();
            List<string> olderFileNames = new List<string>();
            List<string> olderFilePaths = new List<string>();

            List<string> allFileNames = new List<string>(
                    (
                    from filePath
                    in Directory.GetFiles(settings.SourceFilesPath)
                    select Path.GetFileName(filePath)
                    ).ToList()
                );

            DateTime fileDate;

            foreach (string fileName in allFileNames)
            {
                fileDate = ConvertFileNameToDate(fileName);

                if (fileDate.IsEarlierThan(settings.FinalDate))
                {
                    olderFilePaths.Add(settings.SourceFilesPath + @"\" + fileName);
                    olderFileNames.Add(fileName);
                }
            }

            files.Names = olderFileNames;
            files.Paths = olderFilePaths;
            return files;
        }

        private static DateTime ConvertFileNameToDate(string fileName)
        {
            if (DateTime.TryParse(fileName.Remove(10, fileName.Length - 10), out DateTime dateOfFile))
            {
                return dateOfFile;
            }
            throw new Exception("FileInfo. Приведение String к DateTime не удалось.");
        }
    }
}
