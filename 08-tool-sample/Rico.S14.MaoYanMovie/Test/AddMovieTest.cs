using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rico.S14.MaoYanMovie.WdMovie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S14.MaoYanMovie.Test
{
    [TestClass]
    public class AddMovieTest
    {
        [TestMethod]
        public void AddMovieAndPhotoTest()
        {
            var path1 = new DirectoryInfo("../../").FullName;
            var movieHtml1 = File.ReadAllText(path1 + "view-source_maoyan.com_films_247083.html");

            var path2 = new DirectoryInfo("../../").FullName;
            var movieHtml2 = File.ReadAllText(path2 + "view-source_maoyan.com_films_showType=1.html");

            var movieScores = MaoyanManager.FindMovieScoreFormHtml(movieHtml2);

            var movie = MaoyanManager.FindMovieInfoFromHtml(movieHtml1);
            movie.Url = "http://maoyan.com/films/247083";

            var movieScore = movieScores.FirstOrDefault(a => a.MoiveName == movie.MovieName);
            if (movieScore != null)
            {
                movie.MovieScore = movieScore.Score;
            }

            var result = CinemaManager.AddFilm(movie);

            

            Assert.IsTrue(result);
        
        }
    }
}
