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

        public Biblioteca()
        {
            InitializeComponent();
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            bool validarNombre = Utiles.Utiles.ValidarCampo(txtNombreL.Text, "string");
            bool validarISBN = Utiles.Utiles.ValidarCampo(txtISBN.Text, "string");
            bool validarAutor = Utiles.Utiles.ValidarCampo(txtAutor.Text, "string");

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

                Libro libro = new Libro(txtNombreL.Text, txtISBN.Text, txtAutor.Text);
                comboLibroEjemplar.Items.Add($"{libro.Nombre}-{libro.Autor}");
                comboLibroConsulta.Items.Add($"{libro.Nombre}-{libro.Autor}");
                comboLibroPrestamo.Items.Add($"{libro.Nombre}-{libro.Autor}");
                libros.Add(libro);

                txtNombreL.Clear();
                txtISBN.Clear();
                txtAutor.Clear();
            }
        }
        private void btnAgregarSocio_Click(object sender, EventArgs e)
        {
            bool validarNombre = Utiles.Utiles.ValidarCampo(txtNombreS.Text, "string");
            bool validarApellido = Utiles.Utiles.ValidarCampo(txtApellidoS.Text, "string");
            bool validarId = Utiles.Utiles.ValidarCampo(txtIdS.Text, "int");
            bool validarCuota = Utiles.Utiles.ValidarCampo(txtCuota.Text, "double");


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
                    }
                }
                else
                {
                    SocioComun socioComun = new SocioComun(nombre, apellido, id);
                    socios.Add(socioComun);
                }
                txtNombreS.Clear();
                txtApellidoS.Clear();
                txtIdS.Clear();
                txtCuota.Clear();
            }
        }

        private void btnAgregarEjemplar_Click(object sender, EventArgs e)
        {
            bool validarEdicion = Utiles.Utiles.ValidarCampo(txtEdicionEjemplar.Text, "string");
            bool validarUbicacion = Utiles.Utiles.ValidarCampo(txtUbicacionEjemplar.Text, "string");
            bool validarLibro = Utiles.Utiles.ValidarCampo(comboLibroEjemplar.Text, "string");


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
                comboEjemplarPrestamo.Items.Add($"{ejemplar.NroEdicion}-{libro.Nombre}-{libro.Autor}");
                libros.Add(libro);

                txtUbicacionEjemplar.Clear();
                txtEdicionEjemplar.Clear();
                comboLibroEjemplar.Items.Clear();
            }
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultaCupo_Click(object sender, EventArgs e)
        {

        }

        private void btnDevolverEjemplar_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultaEjemplar_Click(object sender, EventArgs e)
        {

        }
    }
}
