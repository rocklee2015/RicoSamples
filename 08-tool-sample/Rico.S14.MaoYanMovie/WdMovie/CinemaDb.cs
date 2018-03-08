namespace Rico.S14.MaoYanMovie.WdMovie
{
    using System.Data.Entity;

    public partial class CinemaDb : DbContext
    {
        public CinemaDb()
            : base("name=CinemaDb")
        {
        }

        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmPhoto> FilmPhoto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
