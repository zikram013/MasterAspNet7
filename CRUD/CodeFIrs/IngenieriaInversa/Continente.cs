using System;
using System.Collections.Generic;

namespace IngenieriaInversa
{
    public partial class Continente
    {
        public Continente()
        {
            Pais = new HashSet<Pais>();
        }

        public int IdContinente { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pais> Pais { get; set; }
    }
}
