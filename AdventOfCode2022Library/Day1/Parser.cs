using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Library.Day1
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

        public ICollection<Elf> ReadElves()
        {
            List<Elf> list = new();
            Elf? elf = null;
            string? line = null;
            int number = 1;
            using (StreamReader stream = new StreamReader(fileStream))
            {
                do
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        if (elf != null)
                        {
                            list.Add(elf);
                        }
                        elf = new Elf(number);
                        number++;
                    }
                    else
                    {
                        elf?.foodList.Add(new Food() { Calories = int.Parse(line) });
                    }

                } while ((line = stream.ReadLine())
                         != null);
            }
            if (elf != null)
            {
                list.Add(elf);
            }
            return list;
        }

        void IDisposable.Dispose() => fileStream.Close();
    }
}
