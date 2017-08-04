namespace Rico.DbFirstSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FilmPhoto")]
    public partial class FilmPhoto
    {
        public Guid Id { get; set; }

        public Guid FilmId { get; set; }

        [Required]
        [StringLength(150)]
        public string Path { get; set; }

        [StringLength(150)]
        public string SourcePath { get; set; }

        public int Sort { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? DeleteTime { get; set; }
    }
}
