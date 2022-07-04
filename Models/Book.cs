using System.ComponentModel.DataAnnotations;

namespace RSWEB_SProekt.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Наслов")]
        public string Title { get; set; }
        [Display(Name = "Година на издавање")]
        public int? ReleaseDate { get; set; }
       
        [StringLength(30, MinimumLength = 3)]
        [Required]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Издавачка куќа")]
        public string? PublishingHouse { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Display(Name = "Број на страници")]
        public int? NumberOfPages { get; set; }

        public int? AuthorId { get; set; }
        [Display(Name = "Автор")]
        public Author? Author { get; set; }
    }
}
