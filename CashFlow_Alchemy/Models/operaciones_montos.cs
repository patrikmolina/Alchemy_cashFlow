using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashFlow_Alchemy.Models
{
    public class operaciones_montos
    {
        public double Total_egreso { get; set; }

        public double Total_ingreso { get; set; }

        public double Total { get; set; }

        public List<Operaciones> Lista_operaciones { get; set; }
    }

}