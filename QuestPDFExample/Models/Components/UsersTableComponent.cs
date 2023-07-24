/*using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPDFExample.Models.Components
{
    public class UsersTableComponent : IComponent
    {
        private IEnumerable<User> Users { get; }

        public UsersTableComponent(IEnumerable<User> users)
        {
            Users = users;
        }

        public void Compose(IContainer container)
        {
            var headerStyle = TextStyle.Default.SemiBold();

            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Text(nameof(User.FullName));
                    header.Cell().Text(nameof(User.Passport));
                });

                foreach (var user in Users)
                {
                    table.Cell().Element(CellStyle).Text(user.FullName);
                    table.Cell().Element(CellStyle).Component(new PassportComponent(user.Passport));

                    static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            });


        }
    }
}*/
