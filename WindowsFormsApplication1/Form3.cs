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
    public partial class Form3 : Form
    {
        Form2 padre;
        public Form3(Form2 padre)
        {
            InitializeComponent();
            this.padre = padre;
            textCodigo.ReadOnly = true;
            textCodigo.Text = getLastCode().ToString("000000");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Preparamos los datos para la inserción
            string cifnif = textCifNif.Text;
            string nombrepila = textNombre.Text;
            string apellidos = textApellidos.Text;
            string nombre = nombrepila + " " + apellidos;
            string sexo = comboSexo.Text;
            string fechaNaci = datePickNaci.Value.ToString("dd-MM-yyyy");
            string codcliente = getLastCode().ToString("000000");
            int code = getLastCode();

            DateTime f_alta = DateTime.Today;
            string alta = f_alta.ToString("dd-MM-yyyy");


            //Preparamos la Query de inserción
            string query = "INSERT INTO clientes(codcliente,nombrepila,apellidos,cifnif,codpago,af_fechaalta,debaja,af_sexo,personafisica,regimeniva,nombre,af_fechanacimiento,af_cuota,copiasfactura,codserie,tipoidfiscal,coddivisa) VALUES('" + codcliente + "','" + nombrepila + "','" + apellidos + "','" + cifnif + "','GIR','" + alta + "','FALSE','" + sexo + "','TRUE','General','" + nombre + "','" + fechaNaci + "',0,1,'A','NIF','EUR')";

            //Añadimos el resgitro en la BBDD
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //Comprobamos que la fila ha sido insertada
            if ((code + 1) == getLastCode())
            {
                MessageBox.Show("Socio añadido correctamente");
                padre.updateForm21(codcliente, nombre, cifnif, conn);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error. El socio no ha sido añadido");
                this.Close();
            }
        }

        private int getLastCode()
        {
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            string query = "SELECT codcliente FROM clientes ORDER BY codcliente DESC";
            OdbcDataAdapter filtro = new OdbcDataAdapter(query, conn);
            DataTable dt = new DataTable();
            filtro.Fill(dt);
            DataRow row = dt.Rows[0];
            string codclientestring = row["codcliente"].ToString();
            int codcliente = int.Parse(codclientestring);
            codcliente = codcliente+1;
            return codcliente;
        }
    }
}
