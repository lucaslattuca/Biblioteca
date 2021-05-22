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

        public Libro()
        {
            Ejemplares = new List<Ejemplar>();
        }

        public Libro(string n, string c, string a)
        {
            Nombre = n;
            CodigoISBN = c;
            Autor = a;
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

        public void PrestarEjemplar()
        {
            if (ConsultarEjemplares())
                Ejemplares.RemoveAt(0);
        }

        public void ReingresarEjemplar(Ejemplar e)
        {
            Ejemplares.Add(e);
        }
    }
}
