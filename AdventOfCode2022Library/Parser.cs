using AdventOfCode2022Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Library
{
    public class Parser : IDisposable
    {
        readonly string filePath;
        readonly FileStream fileStream;
        public Parser(string filePath)
        {
            this.filePath = filePath;
            fileStream = new FileStream(filePath, FileMode.Open);
        }

        public ICollection<T> ReadContent<T>() where T : IMyParsable<T>
        {
            List<T> list = new();
            using (StreamReader stream = new StreamReader(fileStream))
            {
                string? line;
                while ((line = stream.ReadLine()) 
                        != null)
                {
                    list.Add(T.Parse(line));
                }
            }
            return list;
        }

        public ICollection<T> ReadMultilineContent<T>() where T : IMyParsable<T>
        {
            List<T> list = new();
            List<string> lines = new();
            using (StreamReader stream = new(fileStream))
            {
                string? line;
                while ((line = stream.ReadLine())
                       != null)
                {
                    if(string.IsNullOrEmpty(line))
                    {
                        list.Add(T.Parse(string.Join(';', lines)));
                        lines.Clear();
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }
                if (string.IsNullOrEmpty(line))
                {
                    list.Add(T.Parse(string.Join(';', lines)));
                    lines.Clear();
                }
            }
            return list;
        }

        void IDisposable.Dispose() => fileStream.Close();
    }
}
 