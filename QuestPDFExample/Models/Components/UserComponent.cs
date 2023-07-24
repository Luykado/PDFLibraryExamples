using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace QuestPDFExample.Models.Components
{
    public class UserComponent : IComponent
    {
        private User User { get; }

        public UserComponent(User user)
        {
            User = user;
        }

        public void Compose(IContainer container)
        {
            container.ShowEntire().Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.RelativeItem().Component(new GeneralInfoComponent(User));
                    row.ConstantItem(50);
                    row.RelativeItem().Component(new PassportComponent(User.Passport));
                });

                column.Item().Component(new AddressComponent(User.Address));
            });
        }

        private class GeneralInfoComponent : IComponent
        {
            private readonly string _title = "General Information";

            private User User { get; }

            public GeneralInfoComponent(User user)
            {
                User = user;
            }

            public void Compose(IContainer container)
            {
                container.ShowEntire().Column(column =>
                {
                    column.Item().Text(_title).SemiBold();
                    column.Item().LineHorizontal(1);

                    column.Item().Text($"Full Name: {User.FullName}");
                    column.Item().Text($"Birth Date: {User.BirthDate}");
                    column.Item().Text($"Email: {User.Email}");
                    column.Item().Text($"Phone: {User.Phone}");
                    column.Item().Text($"Gender: {User.Gender}");
                });
            }
        }
    }
}
