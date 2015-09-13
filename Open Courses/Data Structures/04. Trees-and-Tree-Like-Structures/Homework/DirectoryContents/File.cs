namespace DirectoryContents
{
    using System;

    public class File
    {
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; set; }

        public long Size { get; set; }

        public override string ToString()
        {
            var file = string.Format("{0} | {1:N2} MB", this.Name, (this.Size / 1024f) / 1024f);

            return file;
        }
    }
}