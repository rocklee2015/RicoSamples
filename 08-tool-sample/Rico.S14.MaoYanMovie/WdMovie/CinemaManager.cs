using Rico.S14.MaoYanMovie.CinemaImage;
using Rico.S14.MaoYanMovie.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Rico.S14.MaoYanMovie.WdMovie
{
    public class CinemaManager
    {
        static UnityContainer Container = new UnityContainer();

        private static CinemaDb _cinemaDbContext;
        static CinemaManager()
        {
            Container.RegisterType(typeof(CinemaDb), new PerThreadLifetimeManager());
        }
        /// <summary>
        /// 数据库上下文 使用依赖注入生成
        /// </summary>
        private static CinemaDb CinemaDbContext
        {
            get
            {
                if (_cinemaDbContext != null) return _cinemaDbContext;
                _cinemaDbContext = Container.Resolve<CinemaDb>();
                return _cinemaDbContext;
            }
        }

        private static string password = "1qaz~xsw2";


        public static bool AddFilm(MaoyanMovie movie)
        {
            try
            {
                using (var dbContext = new CinemaDb())
                {
                    bool isUpdate = false;
                    Film film = null;
                    if (movie.Url == null)
                        return false;
                    film = dbContext.Film.FirstOrDefault(a => a.FilmName == movie.MovieName || a.SourceUrl == movie.Url);
                    if (film != null)
                    {
                        isUpdate = true;
                    }
                    else
                    {
                        film = new Film { Id = Guid.NewGuid() };
                        film.CreateTime = DateTime.Now;

                        var client = new FilmPhotoSoapClient();
                        if (movie.MovieCoverImage.Length > 0)
                        {
                            var picture = ImageHelper.DownloadPicture(movie.MovieCoverImage).Result;
                            string path;
                            string message;
                            client.FilmPosterUpload(password, picture, film.Id, out path, out message);
                            film.CoverPath = path;
                        }
                    }




                    film.FilmName = movie.MovieName;
                    film.ScoreAmount = movie.MovieScore;
                    film.SourceCover = movie.MovieCoverImage;
                    film.SourceUrl = movie.Url;
                    film.Area = movie.MovieArea;
                    film.BriefIntroduction = movie.MovieBrief;
                    film.Director = movie.MovieDirector;
                    film.Duration = movie.MovieDuration;
                    film.MainActor = movie.MovieActor;
                    string dateTimeStr = string.Empty;
                    if (movie.MovieReleaseTime.Length >= 10)
                    {
                        dateTimeStr = movie.MovieReleaseTime.Substring(0, 10);
                    }
                    else if (movie.MovieReleaseTime.Length > 7 && movie.MovieReleaseTime.Length < 10)
                    {
                        dateTimeStr = movie.MovieReleaseTime.Substring(0, 7);
                    }
                    else if (movie.MovieReleaseTime.Length < 5)
                    {
                        dateTimeStr = movie.MovieReleaseTime.Substring(0, 4);
                    }

                    DateTime dateTime = DateTime.MinValue;
                    if (DateTime.TryParse(dateTimeStr, out dateTime))
                    {
                        film.ReleaseDate = dateTime;
                    }

                    //类型
                    Func<string, string> findDes = (s) =>
                    {
                        var type = typeof(Category);
                        var desAttr = type.GetField(s).GetCustomAttributes(typeof(DescriptionAttribute), false).First() as DescriptionAttribute;
                        return desAttr.Description;
                    };
                    var categories = Enum.GetNames(typeof(Category))
                        .Where(i => movie.MovieType.Contains(findDes(i)))
                        .Select(i => (int)Enum.Parse(typeof(Category), i));
                    if (categories.Any())
                    {
                        film.Category = categories.Aggregate((c, n) => c | n);
                    }

                    if (isUpdate)
                    {
                        dbContext.Entry(film).State = EntityState.Modified;
                    }
                    else
                    {
                        dbContext.Film.Add(film);

                    }

                    var imgSvc = new FilmPhotoSoapClient();

                    int num = 1;
                    foreach (var imgUrl in movie.MoviePhoto)
                    {
                        var isExist = dbContext.FilmPhoto.FirstOrDefault(a => a.SourcePath == imgUrl);
                        if (isExist != null)
                        {
                            continue;
                        }
                        var movieImg = ImageHelper.DownloadPicture(imgUrl).Result;
                        var path = "";
                        var message = "";
                        imgSvc.FilmScreenUpload(password, movieImg, film.Id, out path, out message);

                        var filmPhoto = new FilmPhoto
                        {
                            Id = Guid.NewGuid(),
                            SourcePath = imgUrl,
                            Path = path,
                            FilmId = film.Id,
                            Sort = num++,
                            CreateTime = DateTime.Now
                        };


                        dbContext.FilmPhoto.Add(filmPhoto);

                        Console.WriteLine($"【{movie.MovieName}】 完成{((double)num / (double)movie.MoviePhoto.Count).ToString("0%")}");
                        Thread.Sleep(1000);
                    }
                    dbContext.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"【{movie.MovieName}】 出错，{ex.Message}");
                return false;
            }



        }


    }
}
