using Microsoft.AspNetCore.Mvc.Rendering;
using RSWEB_SProekt.Models;

namespace RSWEB_SProekt.ViewModels
{
    public class AuthorFilter
    {
        public IList<Author> Authors { get; set; }
        public string FirstNameString { get; set; }

        public string LastNameString { get; set; }
        public SelectList NationalityList { get; set; }
        public string NationalityString { get; set; }
    }
}
