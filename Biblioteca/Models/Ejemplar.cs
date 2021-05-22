using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    class Ejemplar
    {
        public long NroEdicion { get; set; }
        public string Ubicacion { get; set; }
        public Libro Libro { get; set; }

        public Ejemplar(long nroEdicion, string ubicacion, Libro libro)
        {
            NroEdicion = nroEdicion;
            Ubicacion = ubicacion;
            Libro = libro;
        }
    }
}
