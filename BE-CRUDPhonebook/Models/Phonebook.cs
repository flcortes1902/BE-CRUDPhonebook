
namespace BE_CRUDPhonebook.Models
{
    public class Phonebook
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string TextComments { get; set; }
        public DateTime Date { get; set;  }
    }

}

