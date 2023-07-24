using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace QuestPDFExample.Models.Components
{
    public class AddressComponent : IComponent
    {
        private readonly string _title = "Address Info";

        private Address Address { get; }

        public AddressComponent(Address address)
        {
            Address = address;
        }

        public void Compose(IContainer container)
        {
            container.ShowEntire().Column(column =>
            {
                column.Item().Text(text =>
                {
                    text.Span($"{_title}: ").SemiBold();
                    text.Span($"{Address.City}, {Address.State}, {Address.Street}");
                });
            });
        }
    }
}
