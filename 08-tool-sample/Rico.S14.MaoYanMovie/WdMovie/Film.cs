namespace Rico.S14.MaoYanMovie.WdMovie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        public Guid Id { get; set; }

        public int ReleaseType { get; set; }

        public int Status { get; set; }

        [StringLength(150)]
        public string FilmCode { get; set; }

        [StringLength(150)]
        public string FilmCustomCode { get; set; }

        [Required]
        [StringLength(500)]
        public string FilmName { get; set; }

        [StringLength(500)]
        public string FilmCustomName { get; set; }

        public int? Category { get; set; }

        public string Director { get; set; }

        public string MainActor { get; set; }

        public int? Duration { get; set; }

        [StringLength(150)]
        public string Language { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string FilmSummary { get; set; }

        public string BriefIntroduction { get; set; }

        [StringLength(150)]
        public string Area { get; set; }

        public string CoverPath { get; set; }

        [StringLength(500)]
        public string TrailerPath { get; set; }

        public int? WatchCount { get; set; }

        public decimal? ScoreAmount { get; set; }

        public int? ScoreCount { get; set; }

        [StringLength(150)]
        public string Dimensional { get; set; }

        public string SourceUrl { get; set; }

        public string SourceCover { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? DeleteTime { get; set; }
    }
}
