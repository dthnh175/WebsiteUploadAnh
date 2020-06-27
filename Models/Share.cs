namespace WebsiteUploadAnh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Share
    {
        [StringLength(1)]
        public string Permission { get; set; }

        public int? ImageID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlbumID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShareID { get; set; }

        public virtual ALBUM ALBUM { get; set; }

        public virtual IMAGE IMAGE { get; set; }

        public virtual USER USER { get; set; }
    }
}
