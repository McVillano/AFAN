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

namespace WindowsFormsApplication1
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

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gestionDataSet.clientes' table. You can move, or remove it, as needed.
            this.clientesTableAdapter1.Fill(this.gestionDataSet.clientes);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buttonAdd.Visible = false;
            OdbcConnection conn = this.clientesTableAdapter1.Connection;
            string query = "SELECT codcliente,cifnif,nombre FROM clientes WHERE " + comboFiltro.Text +" LIKE "+ " '" + txtFiltro.Text + "%'";
            OdbcDataAdapter filtro = new OdbcDataAdapter(query, conn);
            DataTable dt = new DataTable();
            filtro.Fill(dt);
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count <= 0)
            {
                buttonAdd.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            string dni = dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString();
            string nombre = dataGridView1.Rows[selectedRowIndex].Cells[2].Value.ToString();
            padre.updateForm1(id,nombre,dni,this.clientesTableAdapter1.Connection);
            this.Close();
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
    }
}
