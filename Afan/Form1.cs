using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Afan
{
    public partial class Form1 : Form
    {
        string codcliente;
        public Form1()
        {
            InitializeComponent();
            buttonAddEnfermo.Visible = false;
            textOtrosDiag.Visible = false;
            textOtrosServicios.Visible = false;
            textOtrosTrat.Visible = false;
            labelOtrosDiag.Visible = false;
            labelOtrosTrat.Visible = false;
            labelOtrosServ.Visible = false;
            labelOCodenfermo.Visible = false;
            labelOSerial.Visible = false;
            textOCodenfermo.Visible = false;
            textOSerial.Visible = false;
            initDataRepeater();
        }

        public static string stringToBBDD(string dato)
        {
            if (string.IsNullOrWhiteSpace(dato))
            {
                return "NULL";
            }
            else
            {
                return dato;
            }
        }

        public static string stringToUUI(string dato)
        {
            if (dato == "NULL")
            {
                return "";
            }
            else
            {
                return dato;
            }
        }

        public void updateForm1(string id, string nombre, string nif, OdbcConnection conn)
        {
            textSocio.Text = nombre;
            this.codcliente = id;
            string query = "SELECT en.nombre, en.apellidos, en.codenfermo FROM af_enfermos en,af_sociosenfermos soc WHERE en.codenfermo=soc.codenfermo AND soc.codcliente LIKE '" + id + "'";
            OdbcDataAdapter filtro = new OdbcDataAdapter(query, conn);
            DataTable dt = new DataTable();
            filtro.Fill(dt);
            comboEnfermo.Items.Clear();
            comboEnfermo.Text = "";
            clearScreen();
            loadInformes();
            foreach (DataRow row in dt.Rows)
            {
                string temp = row["codenfermo"].ToString() + " -----> " + stringToUUI(row["nombre"].ToString()) + " " + stringToUUI(row["apellidos"].ToString())  ;
                comboEnfermo.Items.Add(temp);
            }
            buttonAddEnfermo.Visible = true;
        }
        public void updateForm1(string id,OdbcConnection conn)
        {
            string query = "SELECT en.nombre, en.apellidos, en.codenfermo FROM af_enfermos en,af_sociosenfermos soc WHERE en.codenfermo=soc.codenfermo AND soc.codcliente LIKE '" + id + "'";
            OdbcDataAdapter filtro = new OdbcDataAdapter(query, conn);
            DataTable dt = new DataTable();
            filtro.Fill(dt);
            comboEnfermo.Items.Clear();
            comboEnfermo.Text = "";
            clearScreen();
            loadInformes();
            foreach (DataRow row in dt.Rows)
            {
                string temp = row["codenfermo"].ToString() + " -----> " + stringToUUI(row["nombre"].ToString()) + " " + stringToUUI(row["apellidos"].ToString());
                comboEnfermo.Items.Add(temp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Visible = true;
        }

        private string getEnfermo()
        {
            string temp = comboEnfermo.Text;
            string[] atemp = temp.Split(' ');
            string enfermo=atemp[0];
            return enfermo;
        }

        private void comboEnfermo_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearScreen();
            loadEnfermo(getEnfermo());
            loadDataRepeater();
            loadInformes();
        }

        private void loadEnfermo(string idenfermo)
        {
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            string query = "SELECT * from social WHERE codenfermo LIKE '" + idenfermo + "'";
            OdbcDataAdapter filtro = new OdbcDataAdapter(query, conn);
            DataTable dt = new DataTable();
            filtro.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                //Codigo
                textCodigo.Text =stringToUUI(row["codigo"].ToString());

                //Fecha Nacimiento
                string[] token = row["f_naci"].ToString().Split(' ');
                string[] afecha = token[0].Split('/');
                string dia = afecha[0];
                string mes = afecha[1];
                string año = afecha[2];
                DateTime dateNaci = new DateTime(int.Parse(año), int.Parse(mes), int.Parse(dia));
                datePickNacimiento.Value = dateNaci;

                //Sexo
                comboSexo.Text = stringToUUI(row["sexo"].ToString());

                //Municipio de Residencia
                comboMResidencia.Text = stringToUUI(row["m_resi"].ToString());

                //Fecha de Diagnostico
                token = row["f_diag"].ToString().Split(' ');
                afecha = token[0].Split('/');
                dia = afecha[0];
                mes = afecha[1];
                año = afecha[2];
                DateTime dateDiag = new DateTime(int.Parse(año), int.Parse(mes), int.Parse(dia));
                datePickDiag.Value = dateDiag;

                //Tipo de demencia
                comboTDemencia.Text = stringToUUI(row["t_dem"].ToString());

                //Revisiones Periodicas
                if (row["revisiones"].ToString() == "1")
                {
                    checkRevisiones.Checked = true;
                }

                //Estadio de la Enfermedad
                comboEstadio.Text = row["estadio"].ToString();

                //Otros Diagnosticos
                if (row["hiper"].ToString() == "1")
                {
                    checkHiper.Checked = true;
                }
                if (row["diabetes"].ToString() == "1")
                {
                    checkDiabe.Checked = true;
                }
                if (row["tiroidea"].ToString() == "1")
                {
                    checkTiro.Checked = true;
                }
                if (row["dislipi"].ToString() == "1")
                {
                    checkDislipi.Checked = true;
                }
                if (row["parkinson"].ToString() == "1")
                {
                    checkPark.Checked = true;
                }
                if (!String.IsNullOrWhiteSpace(stringToUUI(row["otrosdiag"].ToString())))
                {
                    textOtrosDiag.Text = row["otrosdiag"].ToString();
                    checkOtrosDiag.Checked = true;
                }

                //Antecedentes
                if (row["vascerebral"].ToString() == "1")
                {
                    checkVascular.Checked = true;
                }
                if (row["cardiovas"].ToString() == "1")
                {
                    checkCardioVascular.Checked = true;
                }
                if (row["craneoen"].ToString() == "1")
                {
                    checkCraneo.Checked = true;
                }
                if (row["depresivo"].ToString() == "1")
                {
                    checkDepre.Checked = true;
                }
                if (row["psicotico"].ToString() == "1")
                {
                    checkPsico.Checked = true;
                }
                if (row["down"].ToString() == "1")
                {
                    checkDown.Checked = true;
                }

                //Idiomas
                comboIdiomas.Text = stringToUUI(row["idiomas"].ToString());

                //Nivel Educativo
                comboNEducativo.Text = stringToUUI(row["neduca"].ToString());

                //Situación Laboral
                comboLaboral.Text = stringToUUI(row["slaboral"].ToString());

                //Municipio Empadronamiento
                comboMPadron.Text = stringToUUI(row["m_empadron"].ToString());

                //Grado de Discapacidad
                comboGDisca.Text = stringToUUI(row["discapaci"].ToString());

                //Grado de Dependencia
                comboGDepen.Text = stringToUUI(row["dependencia"].ToString());

                //Lugar de Residencia
                comboLResi.Text = stringToUUI(row["residencia"].ToString());

                //Nucleo de Convivencia
                comboNConvivencia.Text = stringToUUI(row["convivencia"].ToString());

                //Numero de Personas
                textNPer.Text = row["nper"].ToString();
                textNMen.Text = row["nmen"].ToString();
                textNDep.Text = row["ndep"].ToString();
                textNOPat.Text = row["opat"].ToString();

                //Dispone de Cuidador
                if (row["cuidador"].ToString() == "1")
                {
                    checkCuidador.Checked = true;
                }

                //Relación Cuidador
                comboRCuidador.Text = stringToUUI(row["relcuid"].ToString());

                //Servicios Sociales
                comboSociales.Text = stringToUUI(row["sociales"].ToString());

                //Otros Servicios 
                if (row["teleasist"].ToString() == "1")
                {
                    checkTele.Checked = true;
                }

                if (row["ayudomi"].ToString() == "1")
                {
                    checkAyuda.Checked = true;
                }
                if (row["centrodia"].ToString() == "1")
                {
                    checkDia.Checked = true;
                }
                if (row["antenresi"].ToString() == "1")
                {
                    checkResi.Checked = true;
                }
                if (!String.IsNullOrWhiteSpace(stringToUUI(row["otrosocial"].ToString())))
                {
                    textOtrosServicios.Text = row["otrosocial"].ToString();
                    checkOtrosServicios.Checked = true;
                }

                //Prestaciones Economicas
                comboPrestEco.Text = stringToUUI(row["presecono"].ToString());

                //Vivienda Accesible
                comboVAcess.Text = stringToUUI(row["vivacces"].ToString());

                //Receptor de Ayuda
                comboReAyudas.Text = stringToUUI(row["receptayu"].ToString());

                //Ayuda Tecnica
                comboAyTec.Text = stringToUUI(row["ayudatec"].ToString());

                //Modificación de la Capacidad Juridica
                comboModJur.Text = stringToUUI(row["capajuri"].ToString());

                //Fecha Fallecimiento
                token = row["f_muerte"].ToString().Split(' ');
                afecha = token[0].Split('/');
                dia = afecha[0];
                mes = afecha[1];
                año = afecha[2];
                DateTime datefall = new DateTime(int.Parse(año), int.Parse(mes), int.Parse(dia));
                datePickFall.Value = datefall;
            }

            //Carga Tratamientos
            query = "SELECT fecha,observacion FROM tratamiento WHERE codenfermo LIKE '" + idenfermo + "'";
            filtro = new OdbcDataAdapter(query, conn);
            dt = new DataTable();
            filtro.Fill(dt);
            DataGridViewTextBoxColumn fechaColumn = new DataGridViewTextBoxColumn();
            fechaColumn.HeaderText = "Fecha";
            fechaColumn.Width = 100;
            DataGridViewTextBoxColumn obsColumn = new DataGridViewTextBoxColumn();
            obsColumn.HeaderText = "Tratamiento";
            obsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridTratamientos.Columns.Clear();
            dataGridTratamientos.Columns.AddRange(new DataGridViewTextBoxColumn[] { fechaColumn, obsColumn });
            foreach (DataRow row in dt.Rows)
            {
                dataGridTratamientos.Rows.Add(new String[] { row["fecha"].ToString(), stringToUUI(row["observacion"].ToString()) });
            }
            conn.Close();

            //Load slider lateral
            loadLeftSlider();
        }

        private void clearScreen()
        {
            //Codigo
            textCodigo.Text = "";
            //Fecha Nacimiento
            DateTime dateInit = new DateTime(2016, 01, 01);
            datePickNacimiento.Value = dateInit;
            //Sexo
            comboSexo.Text = "";
            //Municipio de Residencia
            comboMResidencia.Text = "";
            //Fecha de Diagnostico
            datePickDiag.Value = dateInit;
            //Tipo de demencia
            comboTDemencia.Text = "";
            //Revisiones Periodicas
            checkRevisiones.Checked = false;
            //Estadio de la Enfermedad
            comboEstadio.Text = "";
            //Otros Diagnosticos
            checkHiper.Checked = false;
            checkDiabe.Checked = false;
            checkTiro.Checked = false;
            checkDislipi.Checked = false;
            checkPark.Checked = false;
            checkOtrosDiag.Checked = false;
            textOtrosDiag.Text = "";
            //Antecedentes
            checkVascular.Checked = false;
            checkCardioVascular.Checked = false;
            checkCraneo.Checked = false;
            checkDepre.Checked = false;
            checkPsico.Checked = false;
            checkDown.Checked = false;
            //Idiomas
            comboIdiomas.Text = "";
            //Nivel Educativo
            comboNEducativo.Text = "";
            //Situación Laboral
            comboLaboral.Text = "";
            //Municipio Empadronamiento
            comboMPadron.Text = "";
            //Grado de Discapacidad
            comboGDisca.Text = "";
            //Grado de Dependencia
            comboGDepen.Text = "";
            //Lugar de Residencia
            comboLResi.Text = "";
            //Nucleo de Convivencia
            comboNConvivencia.Text = "";
            //Numero de Personas
            textNPer.Text = "";
            textNMen.Text = "";
            textNDep.Text = "";
            textNOPat.Text = "";
            //Dispone de Cuidador
            checkCuidador.Checked = false;
            //Relación Cuidador
            comboRCuidador.Text = "";
            //Servicios Sociales
            comboSociales.Text = "";
            //Otros Servicios 
            checkTele.Checked = false;
            checkAyuda.Checked = false;
            checkDia.Checked = false;
            checkResi.Checked = false;
            checkOtrosServicios.Checked = false;
            textOtrosServicios.Text = "";
            //Prestaciones Economicas
            comboPrestEco.Text = "";
            //Vivienda Accesible
            comboVAcess.Text = "";
            //Receptor de Ayuda
            comboReAyudas.Text = "";
            //Ayuda Tecnica
            comboAyTec.Text = "";
            //Modificación de la Capacidad Juridica
            comboModJur.Text = "";
            //Fecha Fallecimiento
            datePickFall.Value = new DateTime(2025, 01, 01);

            //Limpiamos Tratamientos
            dataGridTratamientos.Rows.Clear();

            //Limpiamos Evolutivos
            DataSet clean = new DataSet();
            dataRepeater1.DataSource = clean;

            //Limpiamos Slider lateral
            treeSlider.Nodes.Clear();
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOtrosDiag.Checked == true)
            {
                textOtrosDiag.Visible = true;
                labelOtrosDiag.Visible = true;
            }
            else if (checkOtrosDiag.Checked == false)
            {
                textOtrosDiag.Visible = false;
                labelOtrosDiag.Visible = false;
            }
        }

        private void checkOtrosServicios_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOtrosServicios.Checked == true)
            {
                textOtrosServicios.Visible = true;
                labelOtrosServ.Visible = true;
            }
            else if (checkOtrosServicios.Checked == false)
            {
                textOtrosServicios.Visible = false;
                labelOtrosServ.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboTrat.Text == "Otros")
            {
                labelOtrosTrat.Visible = true;
                textOtrosTrat.Visible = true;
            }
            else
            {
                labelOtrosTrat.Visible = false;
                textOtrosTrat.Visible = false;
            }
        }

        private void btnAddTrat_Click(object sender, EventArgs e)
        {
            //Preparamos los Datos para la inserción
            string date = datePickTrat.Value.ToString("dd-MM-yyyy");

            //Añadimos el resgitro en la BBDD
            OdbcConnection conn =this.clientesTableAdapter.Connection;
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandType = CommandType.Text;
            if (comboTrat.Text == "Otros")
            {
                cmd.CommandText = "INSERT INTO tratamiento(codenfermo,fecha,observacion) VALUES('"+getEnfermo()+"','" + date + "','" + stringToBBDD(textOtrosTrat.Text)+"');";
            }
            else
            {
                cmd.CommandText = "INSERT INTO tratamiento(codenfermo,fecha,observacion) VALUES('" +getEnfermo()+ "','" + date + "','" + stringToBBDD(comboTrat.Text)+"');";
            }
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //Añadimos esta nueva linea al GRID, limpiando la pantalla y recargando datos
            clearScreen();
            loadEnfermo(getEnfermo());
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Preparamos los Datos para la inserción
            string codigo = stringToBBDD(textCodigo.Text);
            string dateNaci = datePickNacimiento.Value.ToString("dd-MM-yyyy");
            string sexo = stringToBBDD(comboSexo.Text);
            string muniResi = stringToBBDD(comboMResidencia.Text);
            string dateDiag = datePickDiag.Value.ToString("dd-MM-yyyy");
            string tipoDem = stringToBBDD(comboTDemencia.Text);
            string revisiones="";
            if (checkRevisiones.Checked == true) { revisiones = "TRUE"; }
            else { revisiones = "FALSE"; }
            string estadio = comboEstadio.Text;
            string hiper = "";
            if (checkHiper.Checked == true) { hiper = "TRUE"; }
            else { hiper = "FALSE"; }
            string diabe = "";
            if (checkDiabe.Checked == true) {  diabe = "TRUE"; }
            else {  diabe = "FALSE"; }
            string tiroidea = "";
            if (checkTiro.Checked == true) {  tiroidea = "TRUE"; }
            else {  tiroidea = "FALSE";}
            string dislipi = "";
            if (checkDislipi.Checked == true) {  dislipi = "TRUE"; }
            else {  dislipi = "FALSE"; }
            string parkin = "";
            if (checkPark.Checked == true) {  parkin = "TRUE"; }
            else {  parkin = "FALSE"; }
            string otrosDiag = "";
            if (checkOtrosDiag.Checked == true) {  otrosDiag = textOtrosDiag.Text; }
            else {  otrosDiag = "NULL"; }
            string vascular = "";
            if (checkVascular.Checked == true) {  vascular = "TRUE"; }
            else {  vascular = "FALSE"; }
            string cardioVas = "";
            if (checkCardioVascular.Checked == true) {  cardioVas = "TRUE"; }
            else {  cardioVas = "FALSE"; }
            string craneo = "";
            if (checkCraneo.Checked == true) {  craneo = "TRUE"; }
            else {  craneo = "FALSE"; }
            string depre = "";
            if (checkDepre.Checked == true) {  depre = "TRUE"; }
            else {  depre = "FALSE"; }
            string psico = "";
            if (checkPsico.Checked == true) {  psico = "TRUE"; }
            else {  psico = "FALSE"; }
            string down = "";
            if (checkDown.Checked == true) {  down = "TRUE"; }
            else {  down = "FALSE"; }
            string idiomas = stringToBBDD(comboIdiomas.Text);
            string niEduca = stringToBBDD(comboNEducativo.Text);
            string sLaboral = stringToBBDD(comboLaboral.Text);
            string muniEmp = stringToBBDD(comboMPadron.Text);
            string graDis = stringToBBDD(comboGDisca.Text);
            string graDep = stringToBBDD(comboGDepen.Text);
            string luRes = stringToBBDD(comboLResi.Text);
            string nuConv = stringToBBDD(comboNConvivencia.Text);
            int nPer=0;
            if (!string.IsNullOrWhiteSpace(textNPer.Text)){ nPer = int.Parse(textNPer.Text); }
            int nMen=0;
            if (!string.IsNullOrWhiteSpace(textNMen.Text)) { nMen = int.Parse(textNMen.Text); }
            int nDep=0;
            if (!string.IsNullOrWhiteSpace(textNDep.Text)) { nDep = int.Parse(textNDep.Text); }
            int nOt=0;
            if (!string.IsNullOrWhiteSpace(textNOPat.Text)) { nOt = int.Parse(textNOPat.Text); }
            string cuidador = "";
            if (checkCuidador.Checked == true) {  cuidador = "TRUE";}
            else {  cuidador = "FALSE";}
            string relCuid = stringToBBDD(comboRCuidador.Text);
            string sociales = stringToBBDD(comboSociales.Text);
            string tele = "";
            if (checkTele.Checked == true) {  tele = "TRUE";}
            else {  tele = "FALSE";}
            string ayudomi = "";
            if (checkAyuda.Checked == true) {  ayudomi = "TRUE";}
            else {  ayudomi = "FALSE";}
            string dia="";
            if (checkDia.Checked == true) {  dia = "TRUE";}
            else {  dia = "FALSE";}
            string atResi = "";
            if (checkResi.Checked == true) {  atResi = "TRUE";}
            else {  atResi = "FALSE";}
            string otrosServ = "";
            if (checkOtrosServicios.Checked == true) {  otrosServ = textOtrosServicios.Text;}
            else {  otrosServ = "NULL";}
            string presEco = stringToBBDD(comboPrestEco.Text);
            string vivAces = stringToBBDD(comboVAcess.Text);
            string recepAyu = stringToBBDD(comboReAyudas.Text);
            string ayuTec = stringToBBDD(comboAyTec.Text);
            string capJur = stringToBBDD(comboModJur.Text);
            string dateFall = datePickFall.Value.ToString("dd-MM-yyyy");

            //Query
            string query = "INSERT INTO social VALUES('"+codigo+"','"+getEnfermo() + "','" +dateNaci + "','" +sexo + "','" +muniResi + "','" +dateDiag + "','" +tipoDem + "','" +revisiones + "','" +estadio + "','"+idiomas+"','"+niEduca+"','"+sLaboral+"','"+muniEmp+"','"+graDis+"','"+graDep +"','" + luRes + "','" + nuConv + "'," + nPer + "," + nMen + "," + nDep + "," + nOt+",'"+hiper +"','"+diabe+ "','" +tiroidea + "','" +dislipi + "','" +parkin + "','" +otrosDiag + "','" +vascular + "','" +cardioVas + "','" +craneo + "','" +depre + "','" +psico + "','" +down + "','" +cuidador + "','" +relCuid + "','" +sociales + "','" +tele + "','" +ayudomi + "','" +dia + "','" +atResi + "','" +otrosServ + "','" +presEco + "','" +vivAces + "','" +recepAyu + "','" +ayuTec + "','" +capJur + "','" +dateFall+"') ON CONFLICT (codenfermo) DO UPDATE SET codigo='" + codigo + "',f_naci='" + dateNaci + "',sexo='" + sexo + "',m_resi='" + muniResi + "',f_diag='" + dateDiag + "',t_dem='" + tipoDem + "',revisiones='" + revisiones + "',estadio='" + estadio + "',idiomas='" + idiomas + "',neduca='" + niEduca + "',slaboral='" + sLaboral + "',m_empadron='" + muniEmp + "',discapaci='" + graDis + "',dependencia='" + graDep + "',residencia='" + luRes + "',convivencia='" + nuConv + "',nper=" + nPer.ToString() + ",nmen=" + nMen.ToString() + ",ndep=" + nDep.ToString() + ",opat=" + nOt.ToString() + ",hiper='" + hiper + "',diabetes='" + diabe + "',tiroidea='" + tiroidea + "',dislipi='" + dislipi + "',parkinson='" + parkin + "',otrosDiag='" + otrosDiag + "',vascerebral='" + vascular + "',cardiovas='" + cardioVas + "',craneoen='" + craneo + "',depresivo='" + depre + "',psicotico='" + psico + "',down='" + down + "',cuidador='" + cuidador + "',relcuid='" + relCuid + "',sociales='" + sociales + "',teleasist='" + tele + "',ayudomi='" + ayudomi + "',centrodia='" + dia + "',antenresi='" + atResi + "',otrosocial='" + otrosServ + "',presecono='" + presEco + "',vivacces='" + vivAces + "',receptAyu='" + recepAyu + "',ayudatec='" + ayuTec + "',capajuri='" + capJur + "',f_muerte='" + dateFall + "'";

            //Añadimos el resgitro en la BBDD
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = conn;
            conn.Open();
            int ok = cmd.ExecuteNonQuery();
            conn.Close();
            if (ok == 1)
            {
                MessageBox.Show("Información Guardada");
            }

            //Refrescamos pantalla
            clearScreen();
            loadEnfermo(getEnfermo());
        }

        private void buttonAddEnfermo_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(this,codcliente);
            form4.Visible = true;
        }

        private void initDataRepeater()
        {
            //Conectamos con la BBDD
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            conn.Open();
            OdbcCommand cmd = new OdbcCommand();
            OdbcDataAdapter da = new OdbcDataAdapter();

            //Preparamos la query
            string query = "SELECT * FROM evolutivo WHERE codenfermo LIKE '" + getEnfermo() + "'";
            cmd.CommandText = query;
            da.SelectCommand = cmd;
            cmd.Connection = conn;

            //Creamos la DataSheet
            DataSet ds = new DataSet();
            da.Fill(ds);

            //Cerramos la conexion
            conn.Close();

            //Conectar la Informacion con sus Campos
            datePickEvo.DataBindings.Add("Value", da, "fecha");
            textOCodenfermo.DataBindings.Add("Text", da, "codenfermo");
            textOSerial.DataBindings.Add("Text", da, "id");
            richEvo.DataBindings.Add("Text", da, "observacion");
            comboPerfil.DataBindings.Add("Text", da, "perfil");
            dataRepeater1.Visible = true;
        }

        private void loadDataRepeater()
        {
            //Conectamos con la BBDD
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            conn.Open();
            OdbcCommand cmd = new OdbcCommand();
            OdbcDataAdapter da = new OdbcDataAdapter();

            //Preparamos la query
            string query = "SELECT * FROM evolutivo WHERE codenfermo LIKE '" + getEnfermo() + "'";
            cmd.CommandText =query;
            da.SelectCommand = cmd;
            cmd.Connection = conn;

            //Creamos la DataSheet
            DataSet ds = new DataSet();
            da.Fill(ds);

            //Cerramos la conexion
            conn.Close();

            //Conectar la Informacion con el DataRepeater
            dataRepeater1.DataSource = ds.Tables[0];
            
            //Una vez cargados los evolutivos abrimos un espacion nuevo para el siguiente
            dataRepeater1.AddNew();
        }

        private void loadLeftSlider()
        {
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            string query = "SELECT fecha FROM evolutivo WHERE codenfermo LIKE '" + getEnfermo() + "'";
            OdbcDataAdapter filtro = new OdbcDataAdapter(query, conn);
            DataTable dt = new DataTable();
            filtro.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string fecha = row["fecha"].ToString();
                TreeNode node = new TreeNode(fecha);
                treeSlider.Nodes.Add(node);
            }
        }

        private void treeSlider_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tabControlMain.SelectTab(1);
            dataRepeater1.CurrentItemIndex = treeSlider.SelectedNode.Index;
        }

        private int getLasRepeater()
        {
            return (dataRepeater1.ItemCount - 1);
        }

        private void upsertSelected()
        {
            //Preparamos los datos de la inserción
            string serial = dataRepeater1.CurrentItem.Controls["textOSerial"].Text;
            string codenfermo = dataRepeater1.CurrentItem.Controls["textOCodenfermo"].Text;
            string fecha = dataRepeater1.CurrentItem.Controls["datePickEvo"].ToString();
            string[] token = fecha.Split(' ');
            string[] fechas = token[2].Split('/');
            fecha = fechas[0] + "-" + fechas[1] + "-" + fechas[2];
            string perfil = stringToBBDD(dataRepeater1.CurrentItem.Controls["comboPerfil"].Text);
            if (perfil == "NULL") { perfil = "Psicología"; }
            string observacion = stringToBBDD(dataRepeater1.CurrentItem.Controls["richEvo"].Text);

            //Preparamos la query
            string query = "";
            if (String.IsNullOrWhiteSpace(serial))
            {
                query = "INSERT INTO evolutivo(codenfermo,fecha,observacion,perfil) VALUES('" + getEnfermo() + "','" + fecha + "','" + observacion + "','" + perfil + "')";
            }
            else
            {
                query = "UPDATE evolutivo SET fecha='" + fecha + "',observacion='" + observacion + "',perfil='"+perfil+"' WHERE id='" + serial + "'";
            }

            //Insertamos o modificamos la BBDD
            OdbcConnection conn = this.clientesTableAdapter.Connection;
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Guardado");
        }

        private void buttonAddEvol_Click(object sender, EventArgs e)
        {
            upsertSelected();
            dataRepeater1.CurrentItemIndex = getLasRepeater();
            dataRepeater1.AddNew();
        }

        private void buttonSaveEvol_Click(object sender, EventArgs e)
        {
            upsertSelected();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro de que quiere salir?\r\nSe perderán los cambios no guardados", "Leaving App", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            PdfDocument pdf = new PdfDocument();

            DateTime local = DateTime.Now;

            string title = "Informe_" + getEnfermo() + "_" + local.ToString("ddMMyy")+".pdf";
            pdf.Info.Title = title;

            PdfPage pagina = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(pagina);
            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
            gfx.DrawString(richTextBox1.Text, font, XBrushes.Black,
                new XRect(0, 0, pagina.Width, pagina.Height),
                XStringFormats.Center);

            string filepath = "C:/Users/usuario/Desktop/"+title;
            pdf.Save(filepath);
            Process.Start(filepath);
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            string path = "X:/Informes/" + getEnfermo()+"/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            OpenFileDialog save = new OpenFileDialog();
            save.Filter = "Archivo PDF|*.pdf|Todos los Archivos|*.*";
            save.Title = "Guardar Informe";
            save.ShowDialog();
            string[] aux = save.FileName.Split('\\');
            string file = aux[aux.Length - 1];
            if (!string.IsNullOrWhiteSpace(save.FileName))
            {
                File.Copy(save.FileName, path + file);
                loadInformes();
            }
        }

        private void loadInformes()
        {
            string path = "X:/Informes/" + getEnfermo() + "/";
            if (Directory.Exists(path))
            {
                DataGridViewTextBoxColumn nombreColumn = new DataGridViewTextBoxColumn();
                nombreColumn.HeaderText = "Nombre";
                nombreColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridInformes.Columns.Clear();
                dataGridInformes.Columns.AddRange(new DataGridViewTextBoxColumn[] { nombreColumn });
                DirectoryInfo dir = new DirectoryInfo(path);

                foreach (FileInfo file in dir.GetFiles())
                {
                    dataGridInformes.Rows.Add(new String[] {file.Name});
                }
            }
            else
            {
                dataGridInformes.Columns.Clear();
            }
        }

        private void dataGridInformes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dataGridInformes.SelectedCells[0].RowIndex;
            string file = dataGridInformes.Rows[selectedRowIndex].Cells[0].Value.ToString();
            string path = "X:/Informes/" + getEnfermo() + "/" + file;
            Process.Start(path);
        }
    }
}
