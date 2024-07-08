using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Полето {0} е задължително")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Дължината на полето {0} трябва да е {1} символа")]
        [Display(Name = "Телефон")]
        public string Number { get; set; }
    }
}
