﻿using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDFExample.Models.Components;

namespace QuestPDFExample.Models.Documents
{
    public class UsersDocument : IDocument
    {
        public static Image LogoImage { get; } = Image.FromFile("company_logo.png");

        public readonly string _title = "Users Report";

        public IEnumerable<User> Users { get; }

        public DocumentMetadata GetMetadata()
        {
            var documentMetadata = DocumentMetadata.Default;
            documentMetadata.Title = _title;

            return documentMetadata;
        }

        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public UsersDocument(IEnumerable<User> users)
        {
            Users = users;
            QuestPDF.Settings.DocumentLayoutExceptionThreshold = int.MaxValue;
        }

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);
                    page.Header().Component(new HeaderComponent(_title, LogoImage, DateTime.Now, DateTime.Now));
                    page.Content().Element(ComposeContent);
                    page.Footer().Component(new FooterComponent());
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
            });
        }
    }
}
