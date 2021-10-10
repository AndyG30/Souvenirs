using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_logica;

namespace souvenirsApp
{
    public partial class mainScreen : Form
    {
        public mainScreen()
        {
            InitializeComponent();
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {   
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            souvenirController.alta(txtNombreAltas.Text, txtPrecio.Text, Int32.Parse(txtStockAlta.Text), Int32.Parse(txtDescripcion.Text), DateTime.Now);
            MessageBox.Show("Ingreso realizado.");

            txtNombreAltas.Text = "";
            txtPrecio.Text = "";
            txtStockAlta.Text = "";
            txtDescripcion.Text = "";

            dgvSouvenirsBaja.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsModificar.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsVender.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsVentas.DataSource = souvenirController.listarVentas();
        }


        private void mainScreen_Load(object sender, EventArgs e)
        {
           
            dgvSouvenirsBaja.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsModificar.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsVender.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsVentas.DataSource = souvenirController.listarVentas();

            dgvSouvenirsBaja.Columns["id"].Visible = false;
            dgvSouvenirsModificar.Columns["id"].Visible = false;
            dgvSouvenirsVender.Columns["id"].Visible = false;


        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idSouvenir = Int32.Parse(dgvSouvenirsBaja.CurrentRow.Cells[0].Value.ToString());
            souvenirController.baja(idSouvenir);
            MessageBox.Show("Elemento eliminado.");

            dgvSouvenirsBaja.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsModificar.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsVender.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsVentas.DataSource = souvenirController.listarVentas();
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idSouvenir = Int32.Parse(dgvSouvenirsModificar.CurrentRow.Cells[0].Value.ToString());
            string nombre = dgvSouvenirsModificar.CurrentRow.Cells[1].Value.ToString();
            string descripcion = dgvSouvenirsModificar.CurrentRow.Cells[2].Value.ToString();
            int stock = Int32.Parse(dgvSouvenirsModificar.CurrentRow.Cells[3].Value.ToString());
            int precio = Int32.Parse(dgvSouvenirsModificar.CurrentRow.Cells[4].Value.ToString());
            DateTime fecha = DateTime.Parse(dgvSouvenirsModificar.CurrentRow.Cells[5].Value.ToString());
            souvenirController.modificar(idSouvenir, nombre, descripcion, stock, precio, fecha);
            MessageBox.Show("Modificacion realizada.");

            dgvSouvenirsBaja.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsModificar.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsVender.DataSource = souvenirController.listarSouvenirs();
            dgvSouvenirsVentas.DataSource = souvenirController.listarVentas();


        }

       
        private void mainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            int idSouvenir = Int32.Parse(dgvSouvenirsVender.CurrentRow.Cells[0].Value.ToString());
            string nombre = dgvSouvenirsVender.CurrentRow.Cells[1].Value.ToString();
            int stock = Int32.Parse(dgvSouvenirsVender.CurrentRow.Cells[3].Value.ToString());
            int resultado = stock - Int32.Parse(txtCantidad.Text);

            if(stock < Int32.Parse(txtCantidad.Text))
            {
                MessageBox.Show("No hay stock suficiente!");
            }
            else
            {
                souvenirController.vender(idSouvenir, DateTime.Parse(fecha), nombre, resultado, Int32.Parse(txtCantidad.Text));
                MessageBox.Show("Venta realizada.");
                dgvSouvenirsBaja.DataSource = souvenirController.listarSouvenirs();
                dgvSouvenirsModificar.DataSource = souvenirController.listarSouvenirs();
                dgvSouvenirsVender.DataSource = souvenirController.listarSouvenirs();
                dgvSouvenirsVentas.DataSource = souvenirController.listarVentas();

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
        }
    }
}
