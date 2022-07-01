using Microsoft.EntityFrameworkCore;
using RSWEB_SProekt.Data;

namespace RSWEB_SProekt.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RSWEB_SProektContext(serviceProvider.GetRequiredService<DbContextOptions<RSWEB_SProektContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any() || context.Author.Any())
                {
                    return; // DB has been seeded
                }
                context.Author.AddRange(
                new Author { /*Id = 1, */FirstName = "Себастијан", LastName = "Фицек", BirthDate = DateTime.Parse("1971-10-13"), Nationality = "Германец" },
                new Author { /*Id = 2, */FirstName = "Сара", LastName = "Адисон Ален", BirthDate = DateTime.Parse("1971-11-27"), Nationality = "Американец" },
                new Author { /*Id = 3, */FirstName = "Емили", LastName = "Гифин", BirthDate = DateTime.Parse("1972-5-30"), Nationality = "Американец" },
                new Author { /*Id = 1, */FirstName = "Мирјана", LastName = "Проданова", BirthDate = DateTime.Parse("1978-3-6"), Nationality = "Македонец" },
                new Author { /*Id = 2, */FirstName = "Колин", LastName = "Хувер", BirthDate = DateTime.Parse("1979-11-27"), Nationality = "Американец" },
                new Author { /*Id = 3, */FirstName = "Џон", LastName = "Грин", BirthDate = DateTime.Parse("1971-5-30"), Nationality = "Американец" }

                );
                context.SaveChanges();
                context.Book.AddRange(
                new Book { /*Id = 1, */Title = "Во потрага по Алјаска", ReleaseDate = 2005, Genre = "романса", PublishingHouse = "Сакам книги", Price = 370, NumberOfPages = 200, AuthorId = context.Author.Single(x => x.FirstName == "Џон" && x.LastName=="Грин").Id },
                new Book { /*Id = 2, */Title = "Девојката која ја бркаше месечината", ReleaseDate = 2005, Genre = "мистерија", PublishingHouse = "Читај книга", Price = 320, NumberOfPages = 217, AuthorId = context.Author.Single(x => x.FirstName == "Сара" && x.LastName == "Адисон Ален").Id },
                new Book { /*Id = 3, */Title = "Сите ја сакаат Марта", ReleaseDate = 2020, Genre = "трилер", PublishingHouse = "Читај книга", Price = 300, NumberOfPages = 256, AuthorId = context.Author.Single(x => x.FirstName == "Мирјана" && x.LastName == "Проданова").Id },
                new Book { /*Id = 4, */Title = "Сопругата на детективот", ReleaseDate = 2019, Genre = "мистерија", PublishingHouse = "Сакам книги", Price = 400, NumberOfPages = 376, AuthorId = context.Author.Single(x => x.FirstName == "Мирјана" && x.LastName == "Проданова").Id },
                new Book { /*Id = 5, */Title = "Нешто позајмено", ReleaseDate = 2009, Genre = "драма", PublishingHouse = "Сакам книги", Price = 490, NumberOfPages = 272, AuthorId = context.Author.Single(x => x.FirstName == "Емили" && x.LastName == "Гифин").Id },
                new Book { /*Id = 6, */Title = "Пакетот", ReleaseDate = 2009, Genre = "психотрилер", PublishingHouse = "Сакам книги", Price = 400, NumberOfPages = 396, AuthorId = context.Author.Single(x => x.FirstName == "Себастијан" && x.LastName == "Фицек").Id },
                new Book { /*Id = 7, */Title = "Коски на срцето", ReleaseDate = 2016, Genre = "драма", PublishingHouse = "Читај книга", Price = 300, NumberOfPages = 262, AuthorId = context.Author.Single(x => x.FirstName == "Колин" && x.LastName == "Хувер").Id },
                new Book { /*Id = 8, */Title = "Патник 23", ReleaseDate = 2019, Genre = "психотрилер", PublishingHouse = "Сакам книги", Price = 450, NumberOfPages = 402, AuthorId = context.Author.Single(x => x.FirstName == "Себастијан" && x.LastName == "Фицек").Id },
                new Book { /*Id = 9, */Title = "Светот не е фабрика за исполнување желби", ReleaseDate = 2015, Genre = "романса", PublishingHouse = "Сакам книги", Price = 380, NumberOfPages = 232, AuthorId = context.Author.Single(x => x.FirstName == "Џон" && x.LastName == "Грин").Id },
                new Book { /*Id = 10, */Title = "Можеби сега", ReleaseDate = 2018, Genre = "хумор", PublishingHouse = "Сакам книги", Price = 290, NumberOfPages = 156, AuthorId = context.Author.Single(x => x.FirstName == "Колин" && x.LastName == "Хувер").Id }
                );
                context.SaveChanges();


            }
        }
    }
}
