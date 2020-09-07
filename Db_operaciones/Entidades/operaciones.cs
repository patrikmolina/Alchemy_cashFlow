namespace Db_operaciones
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class operaciones
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Concepto { get; set; }

        public double Monto { get; set; }

        public DateTime? Fecha { get; set; }

        [Required]
        [StringLength(10)]
        public string Tipo { get; set; }
    }
}
