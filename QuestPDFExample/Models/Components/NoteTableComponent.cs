using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDFExample.Models;

namespace ReportService.Models.Components
{
    public class NoteTableComponent : IComponent
    {
        private IEnumerable<Note> Notes { get; }

        public NoteTableComponent(IEnumerable<Note> notes)
        {
            Notes = notes;
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
                    header.Cell().Text(nameof(Note.Content));
                    header.Cell().Text(nameof(Note.Description));
                });

                foreach (var note in Notes)
                {
                    table.Cell().Element(CellStyle).Text(note.Content);
                    table.Cell().Element(CellStyle).Text(note.Description);

                    static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            });
        }
    }
}
