using System;
using System.Collections.Generic;

namespace IngenieriaInversa
{
    public partial class Ciudad
    {
        public int IdCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public string Descripcion { get; set; }
        public int Habitantes { get; set; }
        public decimal Altura { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int PaisId { get; set; }

        public virtual Pais Pais { get; set; }
    }
}
