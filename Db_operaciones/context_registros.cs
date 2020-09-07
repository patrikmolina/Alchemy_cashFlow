namespace Db_operaciones
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class context_registros : DbContext
    {
        public context_registros()
            : base("name=context_registros")
        {
        }

        public virtual DbSet<operaciones> operaciones { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<operaciones>()
                .Property(e => e.Concepto)
                .IsUnicode(false);

            modelBuilder.Entity<operaciones>()
                .Property(e => e.Tipo)
                .IsUnicode(false);
        }
    }
}
