using _08.Events.Model;
using Microsoft.AspNetCore.Components;

namespace _08.Events.Shared
{
    public partial class PersonCard
    {
        [Parameter]
        public Person? Person { get; set; }
    }
}
