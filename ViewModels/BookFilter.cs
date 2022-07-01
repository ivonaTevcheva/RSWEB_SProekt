using Microsoft.AspNetCore.Mvc.Rendering;
using RSWEB_SProekt.Models;

namespace RSWEB_SProekt.ViewModels
{
    public class BookFilter
    {
        public IList<Book> Books { get; set; }
        public string TitleString { get; set; }
        public SelectList GenreList { get; set; }
        public string GenreString { get; set; }
        public SelectList SortTypes { get; set; }
        public string Sort { get; set; }
    }
}
