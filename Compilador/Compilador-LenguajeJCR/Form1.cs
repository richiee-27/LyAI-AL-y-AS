using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Compilador_LenguajeJCR
{
    public partial class frmLJCR : Form
    {
        public frmLJCR()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //Función para cargar el archivo de texto 
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Documents | *.txt";
            open.Title = "Cargar Archivo";
            open.Filter = "";
            var o = open.ShowDialog();
            if(o == DialogResult.OK)
            {
                StreamReader read = new StreamReader(open.FileName);
                rtxCodigoFuente.Text = read.ReadToEnd();
                read.Close();
            }

        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            //string Token;

            ////Ciclo que va recorriendo las líneas del código
            //for (int x = 0; x < rtxCodigoFuente.Lines.Count(); x++)
            //{
            //    string cadena = rtxCodigoFuente.Lines[x];
            //    //Ciclo que va evaluando caracter por caracter de la línea en recorrido.
            //    for (int y = 0; y < cadena.Length; y++)
            //    {

            //        //RecorrerMatriz(); 

            //    }

            //}

            //Arreglo de caracteres. 
            string Codigo = rtxCodigoFuente.Text;
            Char[] ArregloCodigo;
             ArregloCodigo = Codigo.ToCharArray();
            int EDO = 0;
            string EDOAC = ""; //Variable para guardar el estado actual para después guardarlo en EDO y seguir analizando.

            label1.Text = ArregloCodigo.Length.ToString();

            SqlConnection cnn = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDA; cnn.Open();
            cmd.CommandText = "SELECT " + ArregloCodigo[0].ToString() + " FROM MatrizLyA WHERE EDO = " + EDO;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dt);
            cnn.Close();

            //for(int i=0; i< ArregloCodigo.Length; i++)
            //{
                 EDOAC = dt.Rows[0][ArregloCodigo[i]].ToString(); //El resultado de esta consulta es guardado en EDOAC
            //}

            //label1.Text = dt.Rows[EDO][ArregloCodigo[0].ToString()].ToString();


        }

    }
}
