using _08.Events.Model;

namespace _08.Events.Pages
{
    public partial class Index
    {
        private readonly Person person = new() { FirstName = "Michele", LastName = "Miller" };

        private void RenameToLaura() => person.FirstName = "Laura";
    }
}
