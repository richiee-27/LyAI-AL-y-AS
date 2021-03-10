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
        Archivos miArhivo;
        string Errors = "";
        int Linea = 1, CantError = 0;
        List<clsSimbolo> lst = new List<clsSimbolo>(); //Lista para almacenar los identificadores
        int COID = 0;
        int ID = 0;
        List<String> lstErrores = new List<string>();
        string tokens2 = "", tokensSem = "";
        MetodoConexion Mimetodo = new MetodoConexion();
        public frmLJCR()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            miArhivo = new Archivos();
            miArhivo.CargarArchivo(rtxCodigoFuente);
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
            CantError = 0;
            Linea = 1;
            lst.Clear();
            rtxErrores.Clear();
            rtxErrores.Update();
            tokens2 = "";
            string strTipo = "", strValor = "";


            for (int i = 0; i < ArregloCodigo.Length; i++)
            {
                if (ArregloCodigo[i].ToString() != " " && ArregloCodigo[i].ToString() != "\n")
                {
                    //Evaluamos espacios en blanco y salto de carro.


                    if (ArregloCodigo[i] >= (char)65 && ArregloCodigo[i] <= (char)90)//Compara si el caracter actual es una mayuscula
                    {
                        EDOAC = Mimetodo.Recorrer(ArregloCodigo, EDO, i);// El resultado de la consulta es guardado en EDOAC (estado actual)
                        EDO = int.Parse(EDOAC);// Se guarda el estado actual en la variable EDO (Estado)
                        Simbolo = Simbolo + ArregloCodigo[i].ToString();
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
                        EDOAC = Mimetodo.RecorrerMin(ArregloCodigo, EDO, i, Aux); //El resultado de esta consulta es guardado en EDOAC
                        EDO = int.Parse(EDOAC);

                        Simbolo = Simbolo + ArregloCodigo[i].ToString();

                    }
                    Bandera = true;
                }
                else
                {
                    if (EDO > 257)
                    {
                        CantError++;
                        EDOAC = Mimetodo.ObtenerToken(EDO);
                        ManejarErrores(EDOAC);
                        lstErrores.Add(EDOAC);
                        Simbolo = "";
                    }
                    else
                    {
                        EDOAC = Mimetodo.ObtenerDel(EDO); //se dirige a la columna DEL para ver a donde ira despues
                        if (EDOAC != "")
                        {
                            EDO = int.Parse(EDOAC); //se guarda en EDO
                            EDOAC = Mimetodo.ObtenerToken(EDO);//Se dirige a la columna TOKEN segun sea el estado y guarda el TOKEN
                        }
                    }
                    // segun sea el caso agregara el salto o el espacio en blanco a la cadena de  tokens
                    EDO = 0;
                    if (EDOAC != "")
                    {
                        if (Simbolo.Contains("."))    // Pregunta si llega a ser constante, si es entera o flotante
                        {
                            EDOAC = "CONF";
                        }
                        else{
                            EDOAC = "CONE";
                        }
                        //string strTipo = "", strValor = "";
                        if (ArregloCodigo[i].ToString() == " ")
                        {
                            //Instrucción temporal para guardar el tipo de dato del identificador.
                            string[] ArrSimb = { "PR02", "PR10", "PR14", "PR01", "PR05", "PR06"};
                          
                            for(int x = 0; x < ArrSimb.Length; x++)
                            {
                                if (EDOAC == ArrSimb[x])
                                {
                                    strTipo = Simbolo;
                                }
                                
                            }
                            if (EDOAC == "IDEN")
                            {
                                ID = GuardarSimbolo(Simbolo, strTipo, strValor); //ALMACENA SIMBOLO
                                tokens2 = tokens2 + EDOAC + " ";
                                Tokens = Tokens + "ID" + ID + " ";
                                foreach (clsSimbolo miSbl in lst)
                                {
                                    if (ID == miSbl.Numero)
                                    {
                                        tokensSem = tokensSem + TipoDatoIDEN(miSbl.TipoDeDato) + " ";
                                    }
                                }

                                Simbolo = "";
                            }
                            else
                            {
                                Simbolo = "";
                                tokensSem = tokensSem + " ";
                                tokens2 = tokens2 + EDOAC + " ";
                                Tokens = Tokens + EDOAC + " ";
                            }
                        }
                        if (ArregloCodigo[i].ToString() == "\n")
                        {

                            if (EDOAC == "IDEN")
                            {
                                ID = GuardarSimbolo(Simbolo,strTipo,strValor);  //ALMACENA SIMBOLO
                                tokens2 = tokens2 + EDOAC + "\n";
                                Tokens = Tokens + "ID" + ID + "\n";
                                foreach (clsSimbolo miSbl in lst)
                                {
                                    if (ID == miSbl.Numero)
                                    {
                                        tokensSem = tokensSem + TipoDatoIDEN(miSbl.TipoDeDato) + "\n";
                                    }
                                }
                                //Simbolo = "";
                            }
                            else
                            {
                                Simbolo = "";
                                tokensSem = tokensSem + EDOAC + "\n";
                                tokens2 = tokens2 + EDOAC + "\n";
                                Tokens = Tokens + EDOAC + "\n";
                            }
                            Linea++;
                        }
                    }
                    else
                    {
                        if (ArregloCodigo[i].ToString() == " ")
                        {
                            Simbolo = "";
                            tokensSem = tokensSem + " ";
                            tokens2 = tokens2 + " ";
                            Tokens = Tokens + " ";
                        }
                        if (ArregloCodigo[i].ToString() == "\n")
                        {
                            Simbolo = "";
                            tokensSem = tokensSem + "\n";
                            tokens2 = tokens2 + "\n";
                            Tokens = Tokens + "\n";
                            Linea++;
                        }
                    }

                }
                if (i == ArregloCodigo.Length - 1)// ES PARA SABER SI ESTAMOS EN EL FINAL DEL ARREGLO
                {
                    if (ArregloCodigo[i].ToString() == " " || ArregloCodigo[i].ToString() == "\n")
                    {
                        rtxTokens.Text = Tokens;
                        return;

                    }
                    if (EDO > 257)
                    {
                        CantError++;
                        EDOAC = Mimetodo.ObtenerToken(EDO);
                        ManejarErrores(EDOAC);
                        lstErrores.Add(EDOAC);
                    }
                    else
                    {
                        EDOAC = Mimetodo.ObtenerDel(EDO); //se dirige a la columna DEL para ver a donde ira despues
                        EDO = int.Parse(EDOAC); //se guarda en EDO
                        EDOAC = Mimetodo.ObtenerToken(EDO);//Se dirige a la columna TOKEN segun sea el estado y guarda el TOKEN
                    }

                    if (EDOAC == "IDEN")
                    {
                        ID = GuardarSimbolo(Simbolo,strValor,strTipo);  //ALMACENA SIMBOLOS
                        tokens2 = tokens2 + EDOAC;
                        Tokens = Tokens + "ID" + ID;
                        foreach(clsSimbolo miSbl in lst)
                        {
                            if(ID == miSbl.Numero)
                            {
                                tokensSem = tokensSem + TipoDatoIDEN(miSbl.TipoDeDato);
                            }
                        }
                        Simbolo = "";
                    }
                    else
                    {
                        tokensSem = tokensSem + EDOAC;
                        tokens2 = tokens2 + EDOAC;
                        Tokens = Tokens + EDOAC;
                    }
                    EDO = 0;

                }

            } rtxTokens.Text = Tokens;
            MessageBox.Show(tokensSem);
            CambiarColor();
        }
        public string TipoDatoIDEN(String TipoDato)
        {
            string cambio = "";
            switch (TipoDato)
            {
                case "Entero":
                    cambio = "IDEN";
                    break;
                case "Flotante":
                    cambio = "IDFL";
                    break;
                case "Cadena":
                    cambio = "IDCA";
                    break;
                case "Caracter":
                    cambio = "IDCE";
                    break;
                case "Bool":
                    cambio = "IDBL";
                    break;
            }
            return cambio;
        }

        public int GuardarSimbolo(string SBL, string Tipo, string Valor)
        {
            clsSimbolo miSimbolo = new clsSimbolo();
            miSimbolo.Numero = COID;
            miSimbolo.Nombre = SBL;
            miSimbolo.Valor = Valor;
            miSimbolo.TipoDeDato = Tipo;
            if (lst.Count == 0)
            {
                lst.Add(miSimbolo);
                lsbSimbolos.Items.Add(miSimbolo.ToString());
                COID++;
                return miSimbolo.Numero;
            }
            else
            {
                foreach (clsSimbolo miSBL in lst)
                {
                    if (miSBL.Equals(miSimbolo))
                    {
                        return miSBL.Numero;
                    }
                }
            }

            lst.Add(miSimbolo);
            lsbSimbolos.Items.Clear();
            foreach (clsSimbolo miSBL in lst)
            {
                lsbSimbolos.Items.Add(miSBL.ToString());

            }
            COID++;
            return miSimbolo.Numero;

        }

        public void ManejarErrores(string error)
        {
            rtxErrores.Text = "";
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
                    Errors = Errors + "ERROR DE OPERADOR LÓGICO EN LA LINEA: " + Linea + "\n";
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
                    Errors = Errors + "ERROR DE CARÁCTER EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "ERCO":
                    Errors = Errors + "ERROR DE CONSTANTE EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "ERCM":
                    Errors = Errors + "ERROR DE COMENTARIO EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
                case "ERDE":
                    Errors = Errors + "ERROR DEL DELIMITANTE EN LA LINEA: " + Linea + "\n";
                    rtxErrores.Text = "CANTIDAD DE ERRORES: " + CantError + "\n" + Errors;
                    break;
            }
        }

        public void CambiarColor()
        {
            for (int i = 0; i < lstErrores.Count; i++)
            {
                int indexOf = 0;
                while (indexOf != -1)
                {
                    indexOf = rtxTokens.Text.IndexOf(lstErrores[i], indexOf);

                    if (indexOf != -1)
                    {
                        rtxTokens.Select(indexOf, lstErrores[i].Length);
                        rtxTokens.SelectionColor = Color.Red;
                        indexOf += lstErrores[i].Length;
                    }
                }
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
            LimpiarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            miArhivo = new Archivos();
            miArhivo.GuardarArchivo(rtxCodigoFuente);
            LimpiarDatos();
        }

        private void rtxCodigoFuente_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void btnTokens_Click(object sender, EventArgs e)
        {
            miArhivo = new Archivos();
            miArhivo.GuardarTokens(rtxCodigoFuente, rtxTokens);
        }

        private void btnSimbolos_Click(object sender, EventArgs e)
        {
            miArhivo = new Archivos();
            miArhivo.AlmacenarSimbolos(rtxCodigoFuente, lsbSimbolos);
        }

        private void btnSintactico_Click(object sender, EventArgs e)
        {
            SqlConnection MiConexion = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            string tokaux = rtxTokens.Text;
            rtxTokens.Text = tokens2;
            int iteracion = 0;
            rtxGramatica.Text = "";
            string primeraCadena = "";
            string segundaCadena = "";

            for (int x = 0; x < rtxTokens.Lines.Count(); x++)
            {
                primeraCadena = rtxTokens.Lines[x];
                segundaCadena = rtxTokens.Lines[x];
                bool bandera = true;
                iteracion = 0;
                do
                {
                    MiConexion.Open();
                    SqlDataReader myDtRd;
                    SqlCommand myQuery = new SqlCommand("SELECT PRODUCCION, VALOR, LEN(VALOR) FROM G ORDER BY PRODUCCION DESC, LEN(VALOR) DESC", MiConexion);
                    myDtRd = myQuery.ExecuteReader();


                    while (myDtRd.Read())
                    {
                        iteracion++;
                        if (primeraCadena.Length >= myDtRd.GetInt32(2))
                        {
                            if (primeraCadena.Replace(myDtRd.GetString(1), myDtRd.GetString(0)) != segundaCadena)
                            {
                                MessageBox.Show("Cadena Principal: " + primeraCadena + "\nSe cambio: " + myDtRd.GetString(1) + "\nPor: " + myDtRd.GetString(0));
                                segundaCadena = primeraCadena.Replace(myDtRd.GetString(1), myDtRd.GetString(0));
                                primeraCadena = segundaCadena;
                                //MessageBox.Show(primeraCadena + "\n" + segundaCadena);
                                rtxGramatica.Text += segundaCadena + "\n";
                                break;
                            }
                        }
                        if (iteracion > 1000) { rtxGramatica.Text += "Linea no aceptada" + "\n"; bandera = false; break; }

                    }
                    MiConexion.Close();

                    if (primeraCadena == "S" || primeraCadena == "S ")
                    {
                        bandera = false;
                        //rtxtGramatica.Text += primeraCadena + "\n";
                        //MessageBox.Show("ya hay una S, el recorrido termino");
                    }

                } while (bandera);
                //MessageBox.Show("ya salio del dowhile");
            }
            //rtxTokens.Text = tokaux;

        }

        public void LimpiarDatos(){
            rtxCodigoFuente.Text = "";
            rtxErrores.Clear();
            rtxErrores.Update();
            rtxTokens.Text = "";
            lsbSimbolos.Items.Clear();
            lst.Clear();
        }

       // { }== LLCE [ ] ( ) ; :
       // S LLCE
    }
}
