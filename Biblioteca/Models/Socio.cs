using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    abstract class Socio
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long NroIdentificacion { get; set; }
        public List<Ejemplar> Ejemplares { get; set; }
        public int CantidadMax { get; set; }


        public abstract bool ConsultarCupo();
        public abstract void DevolverEjemplar(Ejemplar e);
        public abstract string PedirEjemplar(Ejemplar e);

    }
}
