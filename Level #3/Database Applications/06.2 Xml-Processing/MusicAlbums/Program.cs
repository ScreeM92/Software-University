namespace MusicAlbums
{
    using System;
    using MusicAlbumsCatalog;

    public class Program
    {
        public static readonly string Separator = new string('-', 50);

        public static void Main()
        {
            Console.WriteLine("02. Extract Album Names:");
            MusicCatalogParser.ExtractAlbumNames();
            Console.WriteLine(Separator);

            Console.WriteLine("03. Extract All Artists Alphabetically:");
            MusicCatalogParser.ExtractArtistsAlphabetically();
            Console.WriteLine(Separator);

            Console.WriteLine("04. Extract Artists and Number of Albums:");
            MusicCatalogParser.ExtractArtistsWithAlbumsCount();
            Console.WriteLine(Separator);

            Console.WriteLine("05. Extract Artists and Number of Albums with XPath:");
            MusicCatalogParser.ExtractArtistsWithAlbumsCountXPath();
            Console.WriteLine(Separator);

            Console.WriteLine("06. Delete albums with price > 20:");
            MusicCatalogParser.DeleteAlbumWithPriceGreateThan(20M);
            Console.WriteLine(Separator);

            Console.WriteLine("07. Extract albums older that 5 years:");
            MusicCatalogParser.ExtractAlbumlsOlderThan(5);
            Console.WriteLine(Separator);

            Console.WriteLine("08. Extract albums older that 5 years with LINQ:");
            MusicCatalogParser.LinqExtractAlbumsOlderThan(5);
            Console.WriteLine(Separator);

            Console.WriteLine("10. Directory Contents as XML:");
            MusicCatalogParser.GetDirectoryContent();
            Console.WriteLine(Separator);
        }
    }
}
