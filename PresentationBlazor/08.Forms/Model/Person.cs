using _08.Forms.Model.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace _08.Forms.Model
{
    public record Person
    {
        [Required(ErrorMessage = "First name is required", AllowEmptyStrings = false)]
        [NotMarlene]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required", AllowEmptyStrings = false)]
        [StringLength(15, ErrorMessage = "Last name is 15 characters max !")]
        public string LastName { get; set; } = string.Empty;
    }
}
