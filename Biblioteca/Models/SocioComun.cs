using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    class SocioComun : Socio
    {
        public SocioComun(string n, string a, long i)
        {
            Nombre = n;
            Apellido = a;
            NroIdentificacion = i;
            CantidadMax = 3;
            Ejemplares = new List<Ejemplar>();
        }

        public override bool ConsultarCupo()
        {
            if (Ejemplares.Count < 3)
                return true;
            else
                return false;
        }

        public override void DevolverEjemplar(Ejemplar e)
        {
            if (Ejemplares.Count > 0 && Ejemplares.Contains(e))
            {
                Ejemplares.Remove(e);
            }
        }

        public override string PedirEjemplar(Ejemplar e)
        {
            var cupo = ConsultarCupo();

            if (cupo)
            {
                Ejemplares.Add(e);
                return "Ejemplar agregado";
            }
            else return "Superó el límite de ejemplares";
        }
    }
}
