namespace DirectoryContents
{
    using System.IO;

    public class DirectoryContents
    {
        private const string RootPath = @"C:\xampp";
        private const string RootName = "xampp";

        public static void Main()
        {
            var rootFolder = new Folder(RootName, RootPath);
            RecursiveDirectories(rootFolder);
            rootFolder.Print();
        }

        public static void RecursiveDirectories(Folder folder)
        {
            var di = new DirectoryInfo(folder.FullPath);
            var folders = di.GetDirectories();

            foreach (var file in di.GetFiles())
            {
                folder.Files.Add(new File(file.Name, file.Length));
            }

            foreach (var childFolder in folders)
            {
                var newFolder = new Folder(childFolder.Name, childFolder.FullName);
                folder.ChildFolders.Add(newFolder);
                RecursiveDirectories(newFolder);
            }
        }
    }
}