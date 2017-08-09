namespace Rico.DbFirstSample
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

        public byte Status { get; set; }

        public string FilmCode { get; set; }

        public string FilmCustomCode { get; set; }

        [Required]
        [StringLength(150)]
        public string FilmName { get; set; }

        public string FilmCustomName { get; set; }

        public int? Category { get; set; }

        public string Director { get; set; }

        public string MainActor { get; set; }

        public int? Duration { get; set; }

        public string Language { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string FilmSummary { get; set; }

        [StringLength(1000)]
        public string BriefIntroduction { get; set; }

        public string Area { get; set; }

        public string CoverPath { get; set; }

        public string TrailerPath { get; set; }

        public int? WatchCount { get; set; }

        public decimal? ScoreAmount { get; set; }

        public int? ScoreCount { get; set; }

        public string Dimensional { get; set; }

        public string SourceUrl { get; set; }

        public string SourceCover { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? DeleteTime { get; set; }
    }
}
