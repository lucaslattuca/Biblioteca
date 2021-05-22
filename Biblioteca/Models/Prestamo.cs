using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    class Prestamo
    {
        public Ejemplar Ejemplar { get; set; }
        public Socio Socio { get; set; }
        public DateTime Fecha { get; set; }


        public Prestamo(Socio s, Ejemplar e)
        {
            Socio = s;
            Ejemplar = e;
            Fecha = DateTime.Now;
        }

    }
}
