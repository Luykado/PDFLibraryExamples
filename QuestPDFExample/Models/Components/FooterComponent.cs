using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace QuestPDFExample.Models.Components
{
    public class FooterComponent : IComponent
    {
        public void Compose(IContainer container)
        {
            container.AlignCenter().Text(text =>
            {
                text.CurrentPageNumber();
                text.Span(" / ");
                text.TotalPages();
            });
        }
    }
}
