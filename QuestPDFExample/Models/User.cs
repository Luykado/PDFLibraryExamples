using QuestPDFExample.Enums;

namespace QuestPDFExample.Models
{
    public class User
    {
        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public Passport Passport { get; set; }

        public Address Address { get; set; }
    }
}
