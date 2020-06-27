namespace WebsiteUploadAnh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IMAGES")]
    public partial class IMAGE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IMAGE()
        {
            Shares = new HashSet<Share>();
        }

        public int ImageID { get; set; }

        [StringLength(50)]
        public string ImageUrl { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Imagedate { get; set; }

        [StringLength(300)]
        public string ImageCaption { get; set; }

        [StringLength(50)]
        public string ImageLocation { get; set; }

        public int? UserID { get; set; }

        public int? TagID { get; set; }

        public virtual Tag Tag { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Share> Shares { get; set; }
    }
}
