using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Biblioteca : Form
    {
        List<Libro> libros = new List<Libro>();
        List<Socio> socios = new List<Socio>();
        List<Prestamo> prestamos = new List<Prestamo>();

        public Biblioteca()
        {
            InitializeComponent();
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            bool validarNombre = Utiles.Utiles.ValidarCampo(txtNombreL.Text, "string");
            bool validarISBN = Utiles.Utiles.ValidarCampo(txtISBN.Text, "string");
            bool validarAutor = Utiles.Utiles.ValidarCampo(txtAutor.Text, "string");

            try
            {
                if (!validarNombre || !validarISBN || !validarAutor)
                {
                    txtNombreL.BackColor = Color.Red;
                    txtISBN.BackColor = Color.Red;
                    txtAutor.BackColor = Color.Red;
                    MessageBox.Show("Todos los campos son obligatorios");
                }
                else
                {
                    txtNombreL.BackColor = Color.White;
                    txtISBN.BackColor = Color.White;
                    txtAutor.BackColor = Color.White;

                    Libro libro = new Libro(txtNombreL.Text, txtISBN.Text, txtAutor.Text, new List<Ejemplar>());
                    comboLibroEjemplar.Items.Add($"{libro.Nombre}-{libro.Autor}");
                    comboLibroConsulta.Items.Add($"{libro.Nombre}-{libro.Autor}");
                    comboLibroPrestamo.Items.Add($"{libro.Nombre}-{libro.Autor}");
                    libros.Add(libro);

                    MessageBox.Show("Libro agregado con éxito");

                    txtNombreL.Clear();
                    txtISBN.Clear();
                    txtAutor.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al agregar el libro");
            }
        }
        private void btnAgregarSocio_Click(object sender, EventArgs e)
        {
            bool validarNombre = Utiles.Utiles.ValidarCampo(txtNombreS.Text, "string");
            bool validarApellido = Utiles.Utiles.ValidarCampo(txtApellidoS.Text, "string");
            bool validarId = Utiles.Utiles.ValidarCampo(txtIdS.Text, "int");
            bool validarCuota = Utiles.Utiles.ValidarCampo(txtCuota.Text, "double");

            try
            {
                if (!validarNombre || !validarApellido || !validarId)
                {
                    txtNombreS.BackColor = Color.Red;
                    txtApellidoS.BackColor = Color.Red;
                    MessageBox.Show("Todos los campos son obligatorios");
                    if (!validarId)
                    {
                        txtIdS.BackColor = Color.Red;
                        MessageBox.Show("El campo es obligatorio y numerico");
                    }
                    else
                    {
                        txtIdS.BackColor = Color.White;
                    }

                }
                else
                {
                    txtNombreS.BackColor = Color.White;
                    txtApellidoS.BackColor = Color.White;

                    string nombre = txtNombreS.Text;
                    string apellido = txtApellidoS.Text;
                    long id = long.Parse(txtIdS.Text);

                    if (chkSocioVip.Checked)
                    {
                        if (!validarCuota)
                        {
                            txtCuota.BackColor = Color.Red;
                            MessageBox.Show("Debe ingresar un valor de cuota");
                        }
                        else
                        {
                            txtCuota.BackColor = Color.White;
                            double cuota = double.Parse(txtCuota.Text);
                            SocioVip socioVip = new SocioVip(nombre, apellido, id, cuota);
                            socios.Add(socioVip);
                            comboSocioPrestamo.Items.Add($"{socioVip.Nombre}-{socioVip.Apellido}");
                        }
                    }
                    else
                    {
                        SocioComun socioComun = new SocioComun(nombre, apellido, id);
                        socios.Add(socioComun);
                        comboSocioPrestamo.Items.Add($"{socioComun.Nombre}-{socioComun.Apellido}");

                        MessageBox.Show("Socio agregado con éxito");
                    }

                    txtNombreS.Clear();
                    txtApellidoS.Clear();
                    txtIdS.Clear();
                    txtCuota.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al agregar el socio");
            }

        }

        private void btnAgregarEjemplar_Click(object sender, EventArgs e)
        {
            bool validarEdicion = Utiles.Utiles.ValidarCampo(txtEdicionEjemplar.Text, "string");
            bool validarUbicacion = Utiles.Utiles.ValidarCampo(txtUbicacionEjemplar.Text, "string");
            bool validarLibro = Utiles.Utiles.ValidarCampo(comboLibroEjemplar.Text, "string");

            try
            {
                if (!validarUbicacion || !validarLibro || !validarEdicion)
                {
                    txtUbicacionEjemplar.BackColor = Color.Red;
                    comboLibroEjemplar.BackColor = Color.Red;
                    MessageBox.Show("Todos los campos son obligatorios");
                    if (!validarEdicion)
                    {
                        txtEdicionEjemplar.BackColor = Color.Red;
                        MessageBox.Show("El campo es obligatorio y numerico");
                    }
                    else
                    {
                        txtEdicionEjemplar.BackColor = Color.White;
                    }
                }
                else
                {
                    txtUbicacionEjemplar.BackColor = Color.White;
                    comboLibroEjemplar.BackColor = Color.White;

                    string ubicacion = txtUbicacionEjemplar.Text;
                    long edicion = long.Parse(txtEdicionEjemplar.Text);
                    string nombreL = comboLibroEjemplar.Text.Split('-')[0];
                    string autorL = comboLibroEjemplar.Text.Split('-')[1];

                    var libro = libros.Find(i => i.Nombre == nombreL && i.Autor == autorL);

                    Ejemplar ejemplar = new Ejemplar(edicion, ubicacion, libro);

                    libro.AgregarEjemplar(ejemplar);

                    txtUbicacionEjemplar.Clear();
                    txtEdicionEjemplar.Clear();
                    comboLibroEjemplar.Items.Clear();

                    MessageBox.Show("Se agregó el ejemplar con éxito");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al agregar el ejemplar");
            }

        }

        private void btnConsultaEjemplar_Click(object sender, EventArgs e)
        {
            bool validarLibro = Utiles.Utiles.ValidarCampo(comboLibroConsulta.Text, "string");

            if (!validarLibro)
            {
                comboLibroConsulta.BackColor = Color.Red;
                MessageBox.Show("Todos los campos son obligatorios");
            }
            else
            {
                comboLibroConsulta.BackColor = Color.White;

                string nombreL = comboLibroConsulta.Text.Split('-')[0];
                string autorL = comboLibroConsulta.Text.Split('-')[1];

                var libro = libros.Find(i => i.Nombre == nombreL && i.Autor == autorL);

                if (libro.ConsultarEjemplares())
                    MessageBox.Show("El libro posee ejemplares disponibles");
                else
                    MessageBox.Show("El libro no posee ejemplares disponibles");
            }
        }

        private void btnConsultaCupo_Click(object sender, EventArgs e)
        {
            bool validarSocio = Utiles.Utiles.ValidarCampo(comboSocioPrestamo.Text, "string");

            if (socios.Any())
            {
                if (!validarSocio)
                {
                    comboSocioPrestamo.BackColor = Color.Red;
                    MessageBox.Show("Campo obligatorio");
                }
                else
                {
                    comboSocioPrestamo.BackColor = Color.White;

                    string nombreS = comboSocioPrestamo.Text.Split('-')[0];
                    string apellidoS = comboSocioPrestamo.Text.Split('-')[1];

                    var socio = socios.Find(i => i.Nombre == nombreS && i.Apellido == apellidoS);

                    if (socio.ConsultarCupo())
                        MessageBox.Show("El socio puede pedir prestado un ejemplar");
                    else
                        MessageBox.Show("El socio no dispone de cupo para pedir prestado un ejemplar");
                }

            }
            else
                MessageBox.Show("No hay Socios para realizar la consulta");
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            bool validarSocio = Utiles.Utiles.ValidarCampo(comboSocioPrestamo.Text, "string");
            bool validarLibro = Utiles.Utiles.ValidarCampo(comboLibroPrestamo.Text, "string");
            bool validarEjemplar = Utiles.Utiles.ValidarCampo(comboEjemplarPrestamo.Text, "string");

            if (socios.Any() && libros.Any())
            {
                try
                {
                    if (!validarSocio || !validarEjemplar || !validarLibro)
                    {
                        comboSocioPrestamo.BackColor = Color.Red;
                        comboLibroPrestamo.BackColor = Color.Red;
                        comboEjemplarPrestamo.BackColor = Color.Red;
                        MessageBox.Show("Todos los campos son obligatorios");
                    }
                    else
                    {
                        comboSocioPrestamo.BackColor = Color.White;
                        comboLibroPrestamo.BackColor = Color.White;
                        comboEjemplarPrestamo.BackColor = Color.White;

                        string nombreS = comboSocioPrestamo.Text.Split('-')[0];
                        string apellidoS = comboSocioPrestamo.Text.Split('-')[1];
                        var socio = socios.Find(i => i.Nombre == nombreS && i.Apellido == apellidoS);

                        string nombreL = comboLibroPrestamo.Text.Split('-')[0];
                        string autorL = comboLibroPrestamo.Text.Split('-')[1];
                        var libro = libros.Find(i => i.Nombre == nombreL && i.Autor == autorL);

                        long edicionEj = long.Parse(comboEjemplarPrestamo.Text.Split('-')[0]);
                        string libroEj = comboEjemplarPrestamo.Text.Split('-')[1];
                        string autorEj = comboEjemplarPrestamo.Text.Split('-')[2];
                        var ejemplar = libro.Ejemplares.Find(i => i.NroEdicion == edicionEj && i.Libro.Nombre == libroEj && i.Libro.Autor == autorEj);

                        socio.PedirEjemplar(ejemplar);
                        libro.PrestarEjemplar(ejemplar);

                        Prestamo prestamo = new Prestamo(socio, ejemplar);

                        prestamos.Add(prestamo);

                        comboSocioPrestamo.Items.Clear();
                        comboEjemplarPrestamo.Items.Clear();
                        comboLibroPrestamo.Items.Clear();

                        MessageBox.Show("Prestamo realizado con éxito");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error al realizar el prestamo");
                }
            }
            else
                MessageBox.Show("No hay Socios o libros para realizar la acción");
        }

        private void btnDevolverEjemplar_Click(object sender, EventArgs e)
        {
            bool validarSocio = Utiles.Utiles.ValidarCampo(comboSocioDevolucion.Text, "string");
            bool validarEjemplar = Utiles.Utiles.ValidarCampo(comboEjemplarDevolucion.Text, "string");

            if (socios.Any() && libros.Any())
            {
                try
                {
                    if (!validarSocio || !validarEjemplar)
                    {
                        comboSocioDevolucion.BackColor = Color.Red;
                        comboEjemplarDevolucion.BackColor = Color.Red;
                        MessageBox.Show("Todos los campos son obligatorios");
                    }
                    else
                    {
                        comboSocioDevolucion.BackColor = Color.White;
                        comboEjemplarDevolucion.BackColor = Color.White;

                        string nombreS = comboSocioDevolucion.Text.Split('-')[0];
                        string apellidoS = comboSocioDevolucion.Text.Split('-')[1];
                        var socio = socios.Find(i => i.Nombre == nombreS && i.Apellido == apellidoS);

                        long edicionEj = long.Parse(comboEjemplarDevolucion.Text.Split('-')[0]);
                        string libroEj = comboEjemplarDevolucion.Text.Split('-')[1];
                        string autorEj = comboEjemplarDevolucion.Text.Split('-')[2];

                        var libro = libros.Find(i => i.Nombre == libroEj && i.Autor == autorEj);
                        var ejemplar = libro.Ejemplares.Find(i => i.NroEdicion == edicionEj && i.Libro.Nombre == libroEj && i.Libro.Autor == autorEj);

                        socio.DevolverEjemplar(ejemplar);
                        libro.ReingresarEjemplar(ejemplar);

                        comboSocioDevolucion.Items.Clear();
                        comboEjemplarDevolucion.Items.Clear();

                        MessageBox.Show("Devolución realizada con éxito");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Ocurrió un error al realizar la devolución");
                }
            }
            else
                MessageBox.Show("No hay Socios o libros para realizar la acción");
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            lblHistorial.Text = null;
            foreach (var p in prestamos)
            {
                lblHistorial.Text = $"{lblHistorial.Text} \n Fecha: {p.Fecha}";
                lblHistorial.Text = $"{lblHistorial.Text} \n Socio: {p.Socio.Nombre} {p.Socio.Apellido}";
                lblHistorial.Text = $"{lblHistorial.Text} \n Ejemplar: ${p.Ejemplar.NroEdicion} - {p.Ejemplar.Libro.Nombre} - {p.Ejemplar.Libro.Autor}";
                lblHistorial.Text = $"{lblHistorial.Text} \n -------------------------------------";
            }
        }

        private void comboLibroPrestamo_SelectedValueChanged(object sender, EventArgs e)
        {
            bool validarLibro = Utiles.Utiles.ValidarCampo(comboLibroPrestamo.Text, "string");

            if (comboLibroPrestamo.SelectedIndex != -1 && validarLibro)
            {
                string nombreL = comboLibroPrestamo.Text.Split('-')[0];
                string autorL = comboLibroPrestamo.Text.Split('-')[1];

                var libro = libros.Find(i => i.Nombre == nombreL && i.Autor == autorL);

                foreach (var item in libro.Ejemplares)
                {
                    comboEjemplarPrestamo.Items.Add($"{item.NroEdicion}-{libro.Nombre}-{libro.Autor}");
                }

            }
        }

        private void comboSocioDevolucion_SelectedValueChanged(object sender, EventArgs e)
        {
            bool validarSocio = Utiles.Utiles.ValidarCampo(comboSocioDevolucion.Text, "string");

            if (comboSocioDevolucion.SelectedIndex != -1 && validarSocio)
            {
                string nombreS = comboSocioDevolucion.Text.Split('-')[0];
                string apellidoS = comboSocioDevolucion.Text.Split('-')[1];

                var socio = socios.Find(i => i.Nombre == nombreS && i.Apellido == apellidoS);

                foreach (var item in socio.Ejemplares)
                {
                    comboEjemplarDevolucion.Items.Add($"{item.NroEdicion}-{item.Libro.Nombre}-{item.Libro.Autor}");
                }

            }
        }

    }
}
