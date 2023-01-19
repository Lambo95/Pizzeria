namespace Pizzeria.Models
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Utenti")]
    public partial class Utenti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utenti()
        {
            Ordini = new HashSet<Ordini>();
        }

        [Key]
        public int IdUtente { get; set; }

        [StringLength(16)]
        public string Indirizzo { get; set; }

        [StringLength(16)]
        public string Nome { get; set; }

        [StringLength(16)]
        public string Cognome { get; set; }

        [Required]
        [StringLength(16)]
        public string Username { get; set; }

        [Required]
        [StringLength(16)]
        public string Password_ { get; set; }

        public int IdRuolo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }

        public virtual Ruoli Ruoli { get; set; }



    }
}
