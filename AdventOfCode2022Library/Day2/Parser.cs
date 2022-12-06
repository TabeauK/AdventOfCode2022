using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Library.Day2
{
    public class Parser : IDisposable
    {
        readonly string filePath;

        FileStream fileStream;
        public Parser(string filePath)
        {
            this.filePath = filePath;
            fileStream = new FileStream(filePath, FileMode.Open);
        }

        public ICollection<Game> ReadGames(bool outcome = false)
        {
            List<Game> list = new();
            using (StreamReader stream = new StreamReader(fileStream))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    list.Add(new Game(line, outcome));
                }
            }
            return list;
        }

        void IDisposable.Dispose() => fileStream.Close();
    }
}
