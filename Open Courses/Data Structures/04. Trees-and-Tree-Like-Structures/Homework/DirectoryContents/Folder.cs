namespace DirectoryContents
{
    using System;
    using System.Collections.Generic;

    public class Folder
    {
        public Folder(string name, string fullPath)
        {
            this.Name = name;
            this.FullPath = fullPath;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public string FullPath { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> ChildFolders { get; set; }

        public void AddFiles(File file)
        {
            this.Files.Add(file);
        }

        public void AddFolders(Folder folder)
        {
            this.ChildFolders.Add(folder);
        }

        public void Print(int indent = 0)
        {
            Console.Write(new string(' ', 2 * indent));
            Console.WriteLine("=> " + this.Name);

            foreach (var file in this.Files)
            {
                Console.Write(new string(' ', 4 * indent));
                Console.WriteLine(file);
            }

            foreach (var childFolder in this.ChildFolders)
            {
                childFolder.Print(indent + 1);
            }
        }
    }
}