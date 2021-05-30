using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archiver.Models;
using Archiver.Views;

namespace Archiver.Controllers
{
    class ArchiverController : BaseModel
    {
        View view = new View();
        CompressionSettings settings = new CompressionSettings();
        PreparedFiles files = new PreparedFiles();
        FileCompressorLogic compressor = new FileCompressorLogic();
        public ArchiverController()
        {
            settings = XMLReader.GetCompressionSettings();
            files = FileFiltering.GetPreparedFilesList(settings);

            settings.PropertiesSet += view.DisplayXMLResults;
            files.PreparedFilesSet += view.DisplayPreparedFiles;
            compressor.CompressionStarted += view.DisplayStart;
            compressor.CompressionFinished += view.DisplayResult;

            OnLoad();
        }

        public void OnLoad()
        {
            settings.OnPropertiesSet();
            files.OnPreparedFilesSet();
            StartCompression();
        }

        public void StartCompression()
        {
            Console.WriteLine("Нажмите 'Y', чтобы начать сжатие.");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                compressor.CompressAll(files.Paths, settings.CompressedFilesPath);
            }
            else
            {
                Console.WriteLine();
                StartCompression();
            }
        }
    }
}
