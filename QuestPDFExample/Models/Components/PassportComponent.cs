using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace QuestPDFExample.Models.Components
{
    public class PassportComponent : IComponent
    {
        private readonly string _title = "Passport Info";

        private Passport Passport { get; }

        public PassportComponent(Passport passport)
        {
            Passport = passport;
        }

        public void Compose(IContainer container)
        {
            container.ShowEntire().Column(column =>
            {
                column.Item().Text(_title).SemiBold();
                column.Item().LineHorizontal(1);

                column.Item().Text($"Number: {Passport.Number}");
                column.Item().Text($"Series: {Passport.Series}");
                column.Item().Text($"Country: {Passport.Country}");
                column.Item().Text($"Issuer: {Passport.Issuer}");
                column.Item().Text($"Expiration Date: {Passport.ExpirationDate}");
            });
        }
    }
}
