using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fileHandler = new FileHandler();
            //fileHandler.Dispose()
            using(var fileHandler = new FileHandler())
            {
                Console.WriteLine("In using block");
                throw new Exception("HIBAAA");
            }
            Console.WriteLine("Exiting...");
        }
    }

    class FileHandler : IDisposable
    {
        private FileStream _fileStream;
        public FileHandler()
        {
            var filename = Path.GetTempFileName();
            _fileStream = File.OpenWrite(filename);
        }

        ~FileHandler()
        {
            Console.WriteLine("Finalizer!");
            Dispose(false);
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine($"Dispose with {disposing}");
            if(disposing)
            {
                if (_fileStream != null)
                {
                    Console.WriteLine("Disposing file stream.");
                    _fileStream.Dispose();
                    _fileStream = null;
                }
            }
        }
    }
}
