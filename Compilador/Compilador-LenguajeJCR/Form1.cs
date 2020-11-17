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
        string Errors = "";
        int Linea = 1, CantError = 0;
        List<clsSimbolo> lst = new List<clsSimbolo>(); //Lista para almacenar los identificadores
        int COID = 0;
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
            bool Bandera = true;
            string Codigo = rtxCodigoFuente.Text;
            Char[] ArregloCodigo;
             ArregloCodigo = Codigo.ToCharArray();
            int EDO = 0;
            string EDOAC = ""; //Variable para guardar el estado actual para después guardarlo en EDO y seguir analizando.
            string Tokens = "";
            string Aux = ""; //String para consultar la comilla simple
            string Simbolo = "";
         

            for(int i = 0; i < ArregloCodigo.Length; i++)
            {
                if(ArregloCodigo[i].ToString() != " " && ArregloCodigo[i].ToString() != "\n") 
                {
                    //Evaluamos espacios en blanco y salto de carro.

                    Simbolo = Simbolo + ArregloCodigo[i].ToString();
                  
                        if (ArregloCodigo[i] >= (char)65 && ArregloCodigo[i] <= (char)90)//Compara si el caracter actual es una mayuscula
                        {
                            EDOAC = Recorrer(ArregloCodigo, EDO, i);// El resultado de la consulta es guardado en EDOAC (estado actual)
                            EDO = int.Parse(EDOAC);// Se guarda el estado actual en la variable EDO (Estado)
                            Bandera = false;
                            //break;
                        }
                   
                 
                    if (Bandera)
                    {
                        //Evalua si en la cadena viene una comilla simple. 
                        if (ArregloCodigo[i] == (char)39)
                        {
                            Aux = "[s ";
                        }
                        else
                        {
                            Aux = "[s";
                        }
                        EDOAC = RecorrerMin(ArregloCodigo, EDO, i,Aux); //El resultado de esta consulta es guardado en EDOAC
                        EDO = int.Parse(EDOAC);
                          
                    }
                    Bandera = true;
                }
                else
                {
                    if (EDO > 257)
                    {
                        CantError++;
                        EDOAC = ObtenerToken(EDO);
                        ManejarErrores(EDOAC);
                        Simbolo = "";
                    }
                    else
                    {
                        EDOAC = ObtenerDel(EDO); //se dirige a la columna DEL para ver a donde ira despues
                        EDO = int.Parse(EDOAC); //se guarda en EDO
                        EDOAC = ObtenerToken(EDO);//Se dirige a la columna TOKEN segun sea el estado y guarda el TOKEN
                    }
                    // segun sea el caso agregara el salto o el espacio en blanco a la cadena de  tokens
                    EDO = 0;
                    if(ArregloCodigo[i].ToString()==" ")
                    {
                        if (EDOAC == "IDEN")
                        {
                            COID = GuardarSimbolo(Simbolo);
                            Tokens = Tokens + "ID" + COID + " ";
                            Simbolo = "";
                        }
                        else
                        {
                            Tokens = Tokens + EDOAC + " ";
                        }
                    }
                    if(ArregloCodigo[i].ToString() == "\n")
                    {
                        if (EDOAC == "IDEN")
                        {
                            COID = GuardarSimbolo(Simbolo);
                            Tokens = Tokens + "ID" + COID + "\n";
                            Simbolo = "";
                        }
                        else
                        {
                            Tokens = Tokens + EDOAC + "\n";
                        }
                        Linea++;
                    }

                }
                if (i == ArregloCodigo.Length-1)// ES PARA SABER SI ESTAMOS EN EL FINAL DEL ARREGLO
                {
                    if (ArregloCodigo[i].ToString() == " " || ArregloCodigo[i].ToString() == "\n")
                    {
                        rtxTokens.Text = Tokens;
                        return;

                    }
                    if (EDO > 257)
                    {
                        CantError++;
                        EDOAC = ObtenerToken(EDO);
                        ManejarErrores(EDOAC);
                    }
                    else
                    {
                        EDOAC = ObtenerDel(EDO); //se dirige a la columna DEL para ver a donde ira despues
                        EDO = int.Parse(EDOAC); //se guarda en EDO
                        EDOAC = ObtenerToken(EDO);//Se dirige a la columna TOKEN segun sea el estado y guarda el TOKEN
                    }
                    Tokens = Tokens + EDOAC;
                    EDO = 0;
                
                }

            } rtxTokens.Text = Tokens;
 
        }

        public string Recorrer(char [] miArreglo, int intEdo, int indice)
        {
            //Este metodo se manda a llamar solamente cuando se traten de mayúsculas.
            SqlConnection cnn = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDA; cnn.Open();

            cmd.CommandText = "SELECT " + miArreglo[indice].ToString() + " FROM Matriz WHERE EDO = " + intEdo;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dt);
            cnn.Close();

            return dt.Rows[0][miArreglo[indice].ToString()].ToString();
        }
        
        public string ObtenerDel(int edo)
        {
            //Este metodo se manda a llamar solamente cuando se traten de mayúsculas.
            SqlConnection cnn = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDA; cnn.Open();

            cmd.CommandText = "SELECT DEL FROM Matriz WHERE EDO = " + edo;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dt);
            cnn.Close();

            return dt.Rows[0]["DEL"].ToString();
        }
        public string ObtenerToken(int edo)
        {
            //Este metodo se manda a llamar solamente cuando se traten de mayúsculas.
            SqlConnection cnn = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDA; cnn.Open();

            cmd.CommandText = "SELECT TOKEN FROM Matriz WHERE EDO = " + edo;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dt);
            cnn.Close();

            return dt.Rows[0]["TOKEN"].ToString();
        }

        public string RecorrerMin(char [] miArreglo, int intEdo, int indice, string Query)
        {
            //Este metodo se manda a llamar solamente cuando se traten de mayúsculas.
            SqlConnection cnn = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDA; cnn.Open();


            cmd.CommandText = "SELECT " + Query + miArreglo[indice].ToString() + "]" + " FROM Matriz WHERE EDO = " + intEdo;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dt);
            cnn.Close();
            
            if(Query == "[s ")
            return dt.Rows[0]["s " +miArreglo[indice].ToString()].ToString();
            else
            return dt.Rows[0]["s" + miArreglo[indice].ToString()].ToString();

        }

        public int GuardarSimbolo(string SBL)
        {
            clsSimbolo miSimbolo = new clsSimbolo();
            miSimbolo.Numero = COID;
            miSimbolo.Nombre = SBL;
            if(lst.Count == 0)
            {
                lst.Add(miSimbolo);
                lsbSimbolos.Items.Add(miSimbolo.ToString());
            }
            else
            {
                    foreach(clsSimbolo miSBL in lst)
                    {
                      if(miSBL.Equals(miSimbolo))
                        {
                            return miSBL.Numero;
                        }
                    }
            }
            lst.Add(miSimbolo);
            lsbSimbolos.Items.Clear();
            foreach(clsSimbolo miSBL in lst)
            {
                lsbSimbolos.Items.Add(miSBL.ToString());
            }
            return miSimbolo.Numero;
            
        }

        public void ManejarErrores(string error)
        {
            switch (error)
            {
                case "ERPR":
                    Errors = Errors + "ERROR DE PALABRA RESERVADA EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "ERID":
                    Errors = Errors + "ERROR DE IDENTIFICADOR EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "EROL":
                    Errors = Errors + "ERROR DE OPERADOR LÓGICO EN LA LINEA: " + Linea +  "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "EROA":
                    Errors = Errors + "ERROR DE OPERADOR ARITMETICO EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "EROR":
                    Errors = Errors + "ERROR DE OPERADOR RELACIONAL EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "ERCA":
                    Errors = Errors + "ERROR DE CADENA EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "ERCE":
                    Errors = Errors + "ERROR DE CARÁCTER EN LA LINEA: " + Linea +  "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "ERCO":
                    Errors = Errors + "ERROR DE CONSTANTE EN LA LINEA: " + Linea +  "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "ERCM":
                    Errors = Errors + "ERROR DE COMENTARIO EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "ERDE":
                    Errors = Errors + "ERROR DEL DELIMITANTE EN LA LINEA: " + Linea +  "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
            }
        }



        //A partir de aqui se coloca para que ponga el numero de linea
        public int getWidth()
        {
            int w = 40;
            // get total lines of richTextBox1    
            int line = rtxCodigoFuente.Lines.Length;

            if (line <= 99)
            {
                w = 45 + (int)rtxCodigoFuente.Font.Size;
            }
            else if (line <= 999)
            {
                w = 55 + (int)rtxCodigoFuente.Font.Size;
            }
            else
            {
                w = 65 + (int)rtxCodigoFuente.Font.Size;
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
            if (rtxCodigoFuente.Text == "")
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            rtxCodigoFuente.Text = "";
            rtxErrores.Text = "";
            rtxTokens.Text = "";
            lsbSimbolos.Items.Clear();
        }

        private void rtxCodigoFuente_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }
    }
}
