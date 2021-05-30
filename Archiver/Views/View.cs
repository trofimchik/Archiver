using Archiver.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Archiver.Views
{
    class View : BaseModel
    {

        public void DisplayXMLResults(string sourceFilesPath, string compressedFilesPath, DateTime finalDate)
        {
            Console.WriteLine($"Путь к исходным файлам: {sourceFilesPath}" +
                $"\nПуть к сжатым файлам: {compressedFilesPath}\nАрхивировать все файлы до указанной даты: {finalDate}");
        }

        public void DisplayPreparedFiles(List<string> fileNames)
        {
            Console.WriteLine("Файлы подготовленные к архивации:");
            foreach(string fileName in fileNames)
                Console.WriteLine($"{fileName}");
        }

        public void DisplayStart(string sourceFile)
        {
            Console.WriteLine($"Сжатие началась: {Path.GetFileName(sourceFile)} \t");
        }

        public void DisplayResult(string sourceFile, FileStream sourceStream, FileStream targetStream)
        {
            Console.WriteLine("Сжатие завершено: {0}  Начальный размер: {1}  Размер сжатого файла: {2}.\nДата: {3}",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString(), DateTime.Now);
        }
    }
}
