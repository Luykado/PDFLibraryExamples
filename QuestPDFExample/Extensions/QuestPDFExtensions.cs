using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Diagnostics;

namespace QuestPDFExample.Extensions
{
    public static class QuestPDFExtensions
    {
        public delegate void OutputDelegate(string output);

        public static void GenerateReportWithMetrix(this IDocument document, OutputDelegate outputDelegate, string additionalText = null)
        {
            Stopwatch clock = new();
            clock.Start();
            document.GeneratePdf();
            var metadata = document.GetMetadata();
            clock.Stop();

            string defaultMessage = $"{metadata.Title} generation time: {clock.Elapsed}.";
            string outputMessage = additionalText is null ? defaultMessage : $"{defaultMessage} {additionalText}";
            outputDelegate?.Invoke(outputMessage); ;
        }

        public static void GenerateReportAndShowWithMetrix(this IDocument document, OutputDelegate outputDelegate, string additionalText = null)
        {
            Stopwatch clock = new();
            clock.Start();
            document.GeneratePdfAndShow();
            var metadata = document.GetMetadata();
            clock.Stop();

            string defaultMessage = $"{metadata.Title} generation time: {clock.Elapsed}.";
            string outputMessage = additionalText is null ? defaultMessage : $"{defaultMessage} {additionalText}";
            outputDelegate?.Invoke(outputMessage); ;
        }
    }
}
