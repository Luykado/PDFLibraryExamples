using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDFExample.Models.Components;

namespace QuestPDFExample.Models.Documents
{
    public class UsersDocument : IDocument
    {
        public static Image LogoImage { get; } = Image.FromFile("company_logo.png");

        public IEnumerable<User> Users { get; }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public UsersDocument(IEnumerable<User> users)
        {
            Users = users;
        }

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.CurrentPageNumber();
                        text.Span(" / ");
                        text.TotalPages();
                    });
                });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(8);

                foreach (var user in Users)
                {
                    column.Item().Component(new UserComponent(user));
                }
/*
                column.Item().Component(new UsersTableComponent(Users));*/
            });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("Users Report").FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
                    column.Item().Text(text =>
                    {
                        text.Span($"Issue Date: {DateTime.Now.ToShortDateString()}").SemiBold();
                    });
                    column.Item().Text(text =>
                    {
                        text.Span($"Due Date: {DateTime.Now.ToShortDateString()}").SemiBold();
                    });
                });

                row.ConstantItem(92).Image(LogoImage);
            });
        }
    }
}
