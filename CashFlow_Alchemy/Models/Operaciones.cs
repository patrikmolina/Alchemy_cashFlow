using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CashFlow_Alchemy.Models
{
    public class Operaciones
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }


    }
}