using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmAltaPokemon : Form
    {
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elemento = new ElementoNegocio();
            try
            {
            cBoxTipo.DataSource = elemento.listar();
            cBoxDebilidad.DataSource = elemento.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon nuevoPokemon = new Pokemon();
            try
            {
                nuevoPokemon.Numero = int.Parse(txtNumero.Text);
                nuevoPokemon.Nombre = txtNombre.Text;
                nuevoPokemon.Descripcion = txtDescripcion.Text;
                nuevoPokemon.Tipo = (Elemento)cBoxTipo.SelectedItem;
                nuevoPokemon.Debilidad = (Elemento)cBoxDebilidad.SelectedItem;
                PokemonNegocio negocio = new PokemonNegocio();
                negocio.agregar(nuevoPokemon);
                MessageBox.Show("Agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
