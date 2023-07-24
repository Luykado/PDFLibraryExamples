using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using QuestPDFExample.DataSources;
using QuestPDFExample.Models.Documents;
using System.Diagnostics;

namespace QuestPDFExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO: Please make sure that you are eligible to use the Community license.
            // To learn more about the QuestPDF licensing, please visit:
            // https://www.questpdf.com/pricing.html
            Settings.License = LicenseType.Community;

            var users = UserDataSource.GetUsers();
            var document = new UsersDocument(users);

            Stopwatch clock = new Stopwatch();
            clock.Start();
            document.GeneratePdfAndShow();
            clock.Stop();

            // Or open the QuestPDF Previewer and experiment with the document's design
            // in real-time without recompilation after each code change
            // https://www.questpdf.com/document-previewer.html
            //document.ShowInPreviewer();

            Console.WriteLine($"Time you spent for writting it: {clock.Elapsed}");
        }
    }
}
