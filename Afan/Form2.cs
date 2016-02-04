using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Afan
{
    public partial class Form2 : Form
    {
        Form1 padre;
        public Form2(Form1 padre)
        {
            InitializeComponent();
            this.padre = padre;
            buttonAdd.Visible = false;
            comboFiltro.Text = "cifnif";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buttonAdd.Visible = false;
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            string query = "SELECT codcliente,cifnif,nombre FROM clientes WHERE " + comboFiltro.Text +" LIKE "+ " '" + txtFiltro.Text + "%'";
            OdbcDataAdapter filtro = new OdbcDataAdapter(query, conn);
            DataTable dt = new DataTable();
            filtro.Fill(dt);
           this.clientesDataGridView.DataSource = dt;
            if (dt.Rows.Count <= 0)
            {
                buttonAdd.Visible = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.Visible = true;
        }

        public void updateForm21(string id, string nombre, string dni, OdbcConnection conn)
        {
            padre.updateForm1(id, nombre, dni, conn);
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gestionDataSet.clientes' table. You can move, or remove it, as needed.
            this.clientesTableAdapter.Fill(this.gestionDataSet.clientes);

        }

        private void clientesDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = this.clientesDataGridView.SelectedCells[0].RowIndex;
            string id = this.clientesDataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString();
            string dni = this.clientesDataGridView.Rows[selectedRowIndex].Cells[1].Value.ToString();
            string nombre = this.clientesDataGridView.Rows[selectedRowIndex].Cells[2].Value.ToString();
            padre.updateForm1(id, nombre, dni, this.clientesTableAdapter.Connection);
            this.Close();
        }
    }
}
