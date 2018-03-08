using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S14.MaoYanMovie
{
    public class MaoyanMovie
    {
        public MaoyanMovie()
        {
            MoviePhoto = new List<string>();
        }
        public string Url { get; set; }

        public string MovieCoverImage { get; set; }

        public string MovieName { get; set; }

        public string MovieEnglisName { get; set; }

        public string MovieType { get; set; }

        public string MovieArea { get; set; }

        public int MovieDuration { get; set; }

        public string MovieReleaseTime { get; set; }

        public decimal MovieScore { get; set; }

        public string MovieBrief { get; set; }

        public string MovieDirector { get; set; }

        public string MovieActor { get; set; }

        public List<string> MoviePhoto { get; set; }
    }

    public class MaoyanMovieScore
    {
        public string MoiveName { get; set; }
        public decimal Score { get; set; }
    }
}
