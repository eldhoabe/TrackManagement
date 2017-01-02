using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model
{
    public class FileReader : IFileReader
    {
        readonly string _fileName;

        public FileReader(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("The fileName is null or not exist");

            _fileName = fileName;

        }

        public IEnumerable<string> ReadLines()
        {
            return File.ReadLines(_fileName);
        }
    }
}
