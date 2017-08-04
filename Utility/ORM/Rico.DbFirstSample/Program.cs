using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.DbFirstSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var cinemaContext = new CinemaContext())
            {

                var query = cinemaContext.Films.Where(a => !a.IsDeleted);
                var result = query.ToList();
                var film = new Film {Id = Guid.Parse("10593541-A6BA-47E6-9DEC-00255836BFCC"),FilmName = "测试电影-update1", ReleaseType = 2, Status = 1, IsDeleted = false };

                cinemaContext.Films.AddOrUpdate(film);
                cinemaContext.SaveChanges();
            }
        }
    }
}
