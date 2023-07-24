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
            var initialCountUser = 400;
            var finalCountUser = 40000;
            var stepCountUser = 10;

            for (int i = initialCountUser; i <= finalCountUser; i *= stepCountUser)
            {
                var users = UserDataSource.GetUsers(i);
                var usersDocument = new UsersDocument(users);
                usersDocument.GenerateReportWithMetrix(Console.WriteLine, additionalText: $"{i} users");
                //usersDocument.GenerateReportAndShowWithMetrix(Console.WriteLine, additionalText: $"{i} users");
            }

            for (int i = initialCountUser; i <= finalCountUser; i *= stepCountUser)
            {
                var users = UserDataSource.GetUsers(i);
                var usersNotesDocument = new UsersNotesDocument(users);
                usersNotesDocument.GenerateReportWithMetrix(Console.WriteLine, additionalText: $"{i} users");
                //usersNotesDocument.GenerateReportAndShowWithMetrix(Console.WriteLine, additionalText: $"{i} users");
            }
        }
    }
}
