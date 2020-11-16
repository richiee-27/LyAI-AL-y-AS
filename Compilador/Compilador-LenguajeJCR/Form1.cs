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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rtxTokens_TextChanged(object sender, EventArgs e)
        {

        }
        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
            int line = rtxCodigoFuente.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)rtxCodigoFuente.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)rtxCodigoFuente.Font.Size;
            }
            else
            {
                w = 50 + (int)rtxCodigoFuente.Font.Size;
            }

            return w;
        }
        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int First_Index = rtxCodigoFuente.GetCharIndexFromPosition(pt);
            int First_Line = rtxCodigoFuente.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int Last_Index = rtxCodigoFuente.GetCharIndexFromPosition(pt);
            int Last_Line = rtxCodigoFuente.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        private void LineNumberTextBox_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = rtxCodigoFuente.Font;
            rtxCodigoFuente.Select();
            AddLineNumbers();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            rtxCodigoFuente.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void frmLJCR_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void rtxCodigoFuente_KeyDown(object sender, KeyEventArgs e)
        {
            if (rtxCodigoFuente.Text != "")
            {
                AddLineNumbers();
            }
        }

        private void rtxCodigoFuente_TextChanged(object sender, EventArgs e)
        {
            if (rtxCodigoFuente.Text != "")
            {
                AddLineNumbers();
            }
        }

        private void rtxCodigoFuente_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = rtxCodigoFuente.GetPositionFromCharIndex(rtxCodigoFuente.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void rtxCodigoFuente_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }
    }
}
