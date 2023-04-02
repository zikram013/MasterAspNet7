using System;
using System.Collections.Generic;

namespace IngenieriaInversa
{
    public partial class Pais
    {
        public Pais()
        {
            Ciudad = new HashSet<Ciudad>();
        }

        public int IdPais { get; set; }
        public string NombrePais { get; set; }
        public string Descripcion { get; set; }
        public int ContinenteId { get; set; }

        public virtual Continente Continente { get; set; }
        public virtual ICollection<Ciudad> Ciudad { get; set; }
    }
}
