using _08.Forms.Model;
using Microsoft.AspNetCore.Components;

namespace _08.Forms.Shared
{
    public partial class PersonCard
    {
        [Parameter]
        public Person? Person { get; set; }
    }
}
