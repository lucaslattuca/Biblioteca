using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    class Libro
    {
        public string Nombre { get; set; }
        public string CodigoISBN { get; set; }
        public string Autor { get; set; }
        public List<Ejemplar> Ejemplares { get; set; }

        public Libro(string nombre, string codigoISBN, string autor, List<Ejemplar> ejemplares)
        {
            Nombre = nombre;
            CodigoISBN = codigoISBN;
            Autor = autor;
            Ejemplares = ejemplares;
        }

        public void AgregarEjemplar(Ejemplar e)
        {
            Ejemplares.Add(e);
        }
        public bool ConsultarEjemplares()
        {
            if (Ejemplares.Count() > 0)
                return true;
            else
                return false;
        }

        public void PrestarEjemplar(Ejemplar e)
        {
            if (ConsultarEjemplares())
                Ejemplares.Remove(e);
        }

        public void ReingresarEjemplar(Ejemplar e)
        {
            Ejemplares.Add(e);
        }
    }
}
