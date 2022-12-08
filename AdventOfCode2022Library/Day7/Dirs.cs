using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2022Library
{
    public class Dirs : IMyParsable<Dirs>
    {
        readonly List<Dirs> children = new();
        readonly List<File> files = new();

        Dirs? parent;

        string name = "";

        public int size;

        public void CountSize()
        {
            size = files.Sum(x => x.size);
            foreach (Dirs d in children)
            {
                d.CountSize();
                size += d.size;
            }
        }

        public int CountSizeOfSmallDirs(int smallSize)
        {
            return children.Sum(x => x.CountSizeOfSmallDirs(smallSize)) + 
                (size <= smallSize ? size : 0);
        }

        public int? FindSmallestSizeToDelete(int sizeToDelete)
        {
            if(sizeToDelete > size)
            {
                return null;
            }
            if(children.Count == 0 ||
                !children.Where(x => x.FindSmallestSizeToDelete(sizeToDelete) != null).Any()) 
            {
                return size;
            }
            int? minChild = children
                .Where(x => x.FindSmallestSizeToDelete(sizeToDelete) != null)
                .Min(x => x.FindSmallestSizeToDelete(sizeToDelete));
            if (!minChild.HasValue)
            {
                return size;
            }
            return Math.Min(size, minChild.Value);
        }

        public static Dirs Parse(string s)
        {
            string[] lines = s.Split(';');
            int i = 1;
            Dirs directory = new Dirs()
            {
                name = "/",
                parent = null,
                size = 0,
            };
            Dirs temp = directory;
            while (i < lines.Length)
            {
                temp = ParseLine(temp, lines, ref i);
            }
            directory.CountSize();
            return directory;

        }

        public static Dirs ParseLine(Dirs current, string[] lines, ref int nr)
        {
            int i = nr;
            if (lines[i][0] == '$')
            {
                if (lines[i].Substring(2,2) == "cd")
                {
                    nr++;
                    if(lines[i].Length >= 7 && lines[i].Substring(5, 2) == "..")
                    {
                        if(current.parent == null)
                        {
                            throw new NotSupportedException();
                        }
                        return current.parent;
                    }
                    else
                    {
                        Dirs? index = current.children.Find(x => x.name == lines[i][5..]);
                        if(index != null) 
                        {
                            return index;
                        }
                        Dirs newDir = new Dirs()
                        {
                            name = lines[i][5..],
                            parent = current,
                            size = 0,
                        };
                        current.children.Add(newDir);
                        return newDir;
                    }
                }
                else
                {
                    nr++;
                    while (i < lines.Length - 1 && (
                        lines[i + 1].Split(' ')[0] == "dir" ||
                        int.TryParse(lines[i + 1].Split(' ')[0], out int size)))
                    {
                        i++;
                        nr++;
                        if(lines[i].Split(' ')[0] == "dir")
                        {
                            if(!current.children.Any(x => x.name == lines[i].Split(' ')[1]))
                            {
                                current.children.Add(new Dirs()
                                {
                                    name = lines[i].Split(' ')[1],
                                    parent = current,
                                    size = 0,
                                });
                            }
                        }
                        else
                        {
                            current.files.Add(File.Parse(lines[i]));
                        }
                    }

                    return current;
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
