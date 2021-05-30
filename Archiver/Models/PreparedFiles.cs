using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archiver.Models
{
    public class PreparedFiles
    {
        public List<string> Names { get; set; }
        public List<string> Paths { get; set; }

        public event PreparedFilesSetHandler PreparedFilesSet;
        public delegate void PreparedFilesSetHandler(List<string> preparedFiles);
        public void OnPreparedFilesSet()
        {
            PreparedFilesSet?.Invoke(Names);
        }
    }
}
