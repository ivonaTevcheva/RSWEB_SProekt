using System.ComponentModel.DataAnnotations;

namespace RSWEB_SProekt.Models
{
    public class Author
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Презиме")]
        public string LastName { get; set; }

        [Display(Name = "Датум на раѓање")]
        [DataType(DataType.Date)]

        public DateTime? BirthDate { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Националност")]
        public string? Nationality { get; set; }

        [Display(Name = "Автор")]
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public ICollection<Book>? Books { get; set; }
    }
}
