using QuestPDF;
using QuestPDF.Infrastructure;
using QuestPDFExample.DataSources;
using QuestPDFExample.Extensions;
using QuestPDFExample.Models.Documents;

namespace QuestPDFExample
{
    internal class Program
    {
        static void Main()
        {
            // TODO: Please make sure that you are eligible to use the Community license.
            // To learn more about the QuestPDF licensing, please visit:
            // https://www.questpdf.com/pricing.html
            Settings.License = LicenseType.Community;

            //Metric Initialization
            var initialCountUser = 4;
            var finalCountUser = 40000;
            var step = 10;

            for (int i = initialCountUser; i <= finalCountUser; i *= step)
            {
                var users = UserDataSource.GetUsers(i);
                var usersDocument = new UsersDocument(users);
                var text = $"{i} users and pages {i / initialCountUser}";
                usersDocument.GenerateReportWithMetrics(Console.WriteLine, additionalText: text);
                //usersDocument.GenerateReportAndShowWithMetrix(Console.WriteLine, additionalText: text);
            }

            for (int i = initialCountUser; i <= finalCountUser; i *= step)
            {
                var users = UserDataSource.GetUsers(i);
                var usersNotesDocument = new UsersNotesDocument(users);
                var text = $"{i} users and pages {i / initialCountUser}";
                usersNotesDocument.GenerateReportWithMetrics(Console.WriteLine, additionalText: text);
                //usersNotesDocument.GenerateReportAndShowWithMetrix(Console.WriteLine, additionalText: text);
            }
        }
    }
}
