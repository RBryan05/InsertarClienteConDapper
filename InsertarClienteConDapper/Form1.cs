using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsertarClienteConDapper
{
    public partial class Form1 : Form
    {
        PostresRepository _postresRepository = new PostresRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
                var postre = ObtenerPostre();
                int resultado = _postresRepository.IngresarPostre(postre);
                MessageBox.Show($"Se inserto {resultado} postre.");
        }

        private Postres ObtenerPostre()
        {
            Postres postres = new Postres() 
            {
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Descripcion = txtDescripcion.Text,
                FechaVencimiento = dtpFecha.Value,
                Estado = ckbEstado.Checked,
                Stock = int.Parse(txtStock.Text),
                Calorias = int.Parse(txtCalorias.Text),
            };
            return postres;
        }
    }
}
