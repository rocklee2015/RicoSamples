using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S14.MaoYanMovie
{
    [TestClass]
    public class NsoupMaoyanTest
    {
        [TestMethod]
        public void FindMovieTest()
        {
            var path = new DirectoryInfo("../../").FullName;
            var movieHtml = File.ReadAllText(path + "view-source_maoyan.com_films_247083.html");

            var movie = MaoyanManager.FindMovieInfoFromHtml(movieHtml);

            Assert.IsNotNull(movie);
            Assert.AreEqual("闺蜜2", movie.MovieName);
            Assert.AreEqual("Girls 2", movie.MovieEnglisName);


            Console.WriteLine(JsonConvert.SerializeObject(movie));
        }
        [TestMethod]
        public void FindMovieScoreTest()
        {
            var path = new DirectoryInfo("../../").FullName;
            var movieHtml = File.ReadAllText(path + "view-source_maoyan.com_films_showType=1.html");

            var movieScores = MaoyanManager.FindMovieScoreFormHtml(movieHtml);



            Console.WriteLine(JsonConvert.SerializeObject(movieScores));
        }
    }
}
