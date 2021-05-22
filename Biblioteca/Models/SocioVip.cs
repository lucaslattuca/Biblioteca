using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    class SocioVip : Socio
    {
        public double Cuota { get; set; }

        public SocioVip(string n, string a, long i, double c)
        {
            Nombre = n;
            Apellido = a;
            NroIdentificacion = i;
            Cuota = c;
            CantidadMax = 15;
            Ejemplares = new List<Ejemplar>();
        }

        public override bool ConsultarCupo()
        {
            if (Ejemplares.Count < 15)
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
            else
            {
                return "Superó el límite de ejemplares";
            }

        }
    }
}
