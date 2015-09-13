namespace Problem_5.Word_Document_Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WordDocumentGenerator
    {
        public static void Main()
        {
            // You should add DocX library to work next code.
            // Rigth mouse click on "Problem 5. Word Document Generator" -> "Manage NuGet Packages"
            // on search field write "DocX" -> wait to appear and then install
            Problem_5.Word_Document_Generator.DocX_Examples myDocFile = new DocX_Examples();
            myDocFile.CreateSampleDocument();
        }
    }
}
