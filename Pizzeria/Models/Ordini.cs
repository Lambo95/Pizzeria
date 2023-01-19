namespace Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [Key]
        public int IdOrdine { get; set; }

        public bool? Confermato { get; set; }

        public bool? Evaso { get; set; }

        public int IdUtente { get; set; }

        public int IdPizza { get; set; }

        public string Note { get; set; }

        public decimal? Quantita { get; set; }

        public virtual Pizze Pizze { get; set; }

        public virtual Utenti Utenti { get; set; }
    }
}
