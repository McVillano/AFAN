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
    public partial class Form4 : Form
    {
        Form1 padre;
        string codcliente;
        public Form4(Form1 padre,string codcliente)
        {
            InitializeComponent();
            this.padre = padre;
            this.codcliente = codcliente;
            textCodigo.ReadOnly = true;
            textCodigo.Text = getLastCode().ToString("000000");
        }

        private void buttonAddEnfermo_Click(object sender, EventArgs e)
        {
            //Preparamos los datos para la inserción
            string codenfermo = getLastCode().ToString("000000");
            string cifnif = textcifnif.Text;
            string nombre = textNombre.Text;
            string apellidos = textApellidos.Text;
            string direccion = textDireccion.Text;
            string valdependencia = comboDependencia.Text;
            string minusvalia = comboMinusvalía.Text;
            string gradoMinus = textGradoMinusvalía.Text;
            int code = getLastCode();

            //Preparamos la query de inserción
            string query = "INSERT INTO af_enfermos(codenfermo,cifnif,nombre,apellidos,direccion,valdependencia,minusvalia,gradominusvalia) VALUES('" + codenfermo + "','" + cifnif+"','"+nombre + "','" + apellidos + "','" + direccion + "','" + valdependencia + "','" + minusvalia + "'," + gradoMinus + ")";

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
                MessageBox.Show("Enfermo añadido correctamente");
                int code2 = getLasSerial();

                //Relacionamos el Socio y el Enfermo en la tabla af_sociosenfermos
                string query2 = "INSERT INTO af_sociosenfermos(codcliente,parentesco,codenfermo) VALUES('" + codcliente + "','" + textParentesco.Text + "','" + codenfermo + "')";

                //Añadimos el resgitro en la BBDD
                cmd = new OdbcCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query2;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                if ((code2 + 1)<=getLasSerial())
                {
                    MessageBox.Show("Enfermo y Socio relacionados");
                    padre.updateForm1(codcliente, conn);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error. El enfermo no ha sido relacionado con el Socio");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error. El enfermo no ha sido añadido");
                this.Close();
            }
        }

        private int getLastCode()
        {
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            string query = "SELECT codenfermo FROM af_enfermos ORDER BY codenfermo DESC";
            OdbcDataAdapter filtro = new OdbcDataAdapter(query, conn);
            DataTable dt = new DataTable();
            filtro.Fill(dt);
            DataRow row = dt.Rows[0];
            string codenfermostring = row["codenfermo"].ToString();
            int codenfermo = int.Parse(codenfermostring);
            codenfermo = codenfermo + 1;
            return codenfermo;
        }

        private int getLasSerial()
        {
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            string query = "SELECT idsociosenfermos FROM af_sociosenfermos ORDER BY idsociosenfermos DESC";
            OdbcDataAdapter filtro = new OdbcDataAdapter(query, conn);
            DataTable dt = new DataTable();
            filtro.Fill(dt);
            DataRow row = dt.Rows[0];
            string codenfermostring = row["idsociosenfermos"].ToString();
            int codenfermo = int.Parse(codenfermostring);
            return codenfermo;
        }
    }
}
