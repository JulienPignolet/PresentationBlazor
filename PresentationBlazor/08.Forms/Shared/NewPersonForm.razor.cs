using _08.Forms.Model;
using Microsoft.AspNetCore.Components;

namespace _08.Forms.Shared
{
    public partial class NewPersonForm
    {
        [Parameter]
        public EventCallback<Person> OnNewPerson { get; set; }

        private Person person = new();

        private async Task AddNewPerson()
        {
            await OnNewPerson.InvokeAsync(person);
            person = new();
        }
    }
}
