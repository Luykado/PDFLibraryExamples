using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPDFExample.Models.Components
{
    public class HeaderComponent : IComponent
    {
        private string Title { get; }

        private Image LogoImage { get; }

        private DateTime IssueDate { get; }

        private DateTime DueDate { get; }

        public HeaderComponent(
            string title, 
            Image logoImage,
            DateTime issueDate,
            DateTime dueDate)
        {
            Title = title;
            LogoImage = logoImage;
            IssueDate = issueDate;
            DueDate = dueDate;
        }

        public void Compose(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text(Title).FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
                    column.Item().Text(text =>
                    {
                        text.Span($"Issue Date: {IssueDate.ToShortDateString()}").SemiBold();
                    });
                    column.Item().Text(text =>
                    {
                        text.Span($"Due Date: {DueDate.ToShortDateString()}").SemiBold();
                    });
                });

                row.ConstantItem(92).Image(LogoImage);
            });
        }
    }
}
