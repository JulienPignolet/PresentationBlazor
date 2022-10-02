using _08.Forms.Model;

namespace _08.Forms.Pages
{
    public partial class Index
    {
        private readonly List<Person> persons;

        public Index()
        {
            persons = new List<Person>() 
            { 
                new Person { FirstName = "Michele", LastName = "Miller" } 
            };
        }

        private void AddNewPerson(Person person) => persons.Add(person);
    }
}
