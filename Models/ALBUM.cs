namespace WebsiteUploadAnh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALBUMS")]
    public partial class ALBUM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALBUM()
        {
            Shares = new HashSet<Share>();
        }

        public int AlbumID { get; set; }

        [StringLength(100)]
        public string AlbumName { get; set; }

        [StringLength(1000)]
        public string AlbumCaption { get; set; }

        public int? UserID { get; set; }

        public int? Tagid { get; set; }

        public virtual Tag Tag { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Share> Shares { get; set; }
    }
}
