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
            SqlConnection cnn = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDA; cnn.Open();

            char c1 = 'A';
            bool Bandera = true;
            string Codigo = rtxCodigoFuente.Text;
            Char[] ArregloCodigo;
             ArregloCodigo = Codigo.ToCharArray();
            int EDO = 0;
            string EDOAC = ""; //Variable para guardar el estado actual para después guardarlo en EDO y seguir analizando.

            label1.Text = ArregloCodigo.Length.ToString();

            //Metodo para controlar minúsculas, numeros y caracteres especiales. 
            cmd.CommandText = "SELECT s" + ArregloCodigo[0].ToString() + " FROM MatrizLyA WHERE EDO = " + EDO;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dt);
            cnn.Close();

            for(int i = 0; i < ArregloCodigo.Length; i++)
            {
                //Evaluamos espacios en blanco y salto de carro.

                for(int L = 1; L <= 26; L++)
                {
                    if(ArregloCodigo[i] == c1)
                    {
                        EDOAC = Recorrer(ArregloCodigo, EDO, i);
                        Bandera = false;
                        break;
                    }
                    else
                    {
                        c1++;
                    }
                }
                //Aquí termina for de Mayúsculas
                if (Bandera)
                {
                    EDOAC = dt.Rows[EDO]["s" + ArregloCodigo[i].ToString()].ToString(); //El resultado de esta consulta es guardado en EDOAC
                }
            }
        }

        public string Recorrer(char [] miArreglo, int intEdo, int indice)
        {
            //Este metodo se manda a llamar solamente cuando se traten de mayúsculas.
            SqlConnection cnn = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDA; cnn.Open();

            cmd.CommandText = "SELECT " + miArreglo[indice].ToString() + " FROM MatrizLyA WHERE EDO = " + intEdo;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dt);
            cnn.Close();

            return dt.Rows[intEdo][miArreglo[indice].ToString()].ToString();
        }

    }
}
