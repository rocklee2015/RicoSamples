using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Rico.S14.MaoYanMovie
{
    public class MaoyanManager
    {
        public static List<MaoyanMovieScore> FindMovieScoreFormHtml(string htmlDoc)
        {
            var movieScores = new List<MaoyanMovieScore>();
            var doc = NSoup.NSoupClient.Parse(htmlDoc, "utf-8");
            var movieBrief = doc.GetElementsByClass("movies-list");

            var movieList = movieBrief.Select("dd").ToList();
            foreach (var item in movieList)
            {
                var movieName = item.Select(".movie-item-title").Attr("title");
                var scoreText = item.Select(".integer").Text + item.Select(".fraction").Text;
                double movieScore = 0;
                double.TryParse(scoreText, out movieScore);
                movieScores.Add(new MaoyanMovieScore()
                {
                    MoiveName = movieName,
                    Score = movieScore
                });

            }
            return movieScores;
        }
        public static MaoyanMovie FindMovieInfoFromHtml(string htmlDoc)
        {
            var movie = new MaoyanMovie();
            NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(htmlDoc, "utf-8");
            var movieBrief = doc.GetElementsByClass("movie-brief-container");

            if (movieBrief == null)
                return null;
            //影片名称
            movie.MovieName = movieBrief.Select(".name").Text;
            movie.MovieEnglisName = movieBrief.Select(".ename").Text;

            //类型
            movie.MovieType = movieBrief.Select("ul>li")[0].Text();

            //地区，时长
            var areaTime = movieBrief.Select("ul>li")[1].Text();
            var array = areaTime.Split('/');
            movie.MovieArea = array.Length > 0 ? array[0] : "";
            var duration = array.Length > 1 ? array[1] : "";
            movie.MovieDuration = System.Text.RegularExpressions.Regex.Replace(duration, @"[^0-9]+", "");

            //上映日期
            var releaseTime = movieBrief.Select("ul>li")[2].Text();
            releaseTime = System.Text.RegularExpressions.Regex.Replace(releaseTime, @"[^0-9|-]+", "");
            movie.MovieReleaseTime = releaseTime;

            //影评分手（评分是字体图标无法抓取）
            var scoreText = doc.GetElementsByClass("info-num").Select(".stonefont").Text;
            scoreText = HttpUtility.UrlDecode(scoreText);
            double score = 0;
            double.TryParse(scoreText, out score);
            movie.MovieScore = score;

            //简介
            movie.MovieBrief = doc.GetElementsByClass("mod-content").Select(".dra").Text;

            //导演
            movie.MovieDirector = doc.GetElementsByClass("celebrity-group")[0].Select(".name").Text;

            //导演
            var actors = doc.GetElementsByClass("celebrity-group")[1].Select(".name").ToList().Select(a => a.Text());
            movie.MovieActor = string.Join(",", actors);

            //图集
            var photos = doc.GetElementsByClass("tab-img").Select("img").Take(30).ToList();
            foreach (var photo in photos)
            {
                var photoUrl = photo.Attributes["data-src"];
                movie.MoviePhoto.Add(photoUrl);
            }
            return movie;
        }

    }
}
