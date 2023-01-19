namespace Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Pizze")]
    public partial class Pizze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pizze()
        {
            Ordini = new HashSet<Ordini>();
        }

        [Key]
        public int IdPizza { get; set; }

        [Required]
        [StringLength(16)]
        public string Nome { get; set; }

        public string UrlImg { get; set; }

        [Column(TypeName = "money")]
        public decimal Prezzo { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [NotMapped()]
        public HttpPostedFileBase FileFoto { get; set; }
        public int TempoPreparazione { get; set; }

        
        public int Quantita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }
    }
}
