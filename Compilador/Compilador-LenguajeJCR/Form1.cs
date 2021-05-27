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
        string Errors = "",CadAux2 ="";
        int Linea = 1, CantError = 0, Temporal = 1;
        List<clsSimbolo> lst = new List<clsSimbolo>(); //Lista para almacenar los identificadores
        //List<> ErrorSeman = new List<>();
        int COID = 0;
        int ID = 0;
        List<String> lstErrores = new List<string>();
        string tokens2 = "", tokensSem = "";
        MetodoConexion Mimetodo = new MetodoConexion();
        int numeroError = 0;
        //List<ErroresSem> lstErrorSem = new List<ErroresSem>(); //Lista para almacenar para errores semanticos
        //ErroresSem mierror;
        List<Tupla> listTuplas = new List<Tupla>();
        public frmLJCR()
        {
            InitializeComponent();
            //ErrorSeman.Add("PR10 EXP2ASIG EXP3 DEIN");
            //ErrorSeman.Add("EXP2ASIG EXP4 DEIN");
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
                        if (EDOAC == "CONS")
                        {
                            if (Simbolo.Contains("."))    // Pregunta si llega a ser constante, si es entera o flotante
                            {
                                EDOAC = "CONF";
                            }
                            else
                            {
                                EDOAC = "CONE";
                            }
                        }
                        //string strTipo = "", strValor = "";
                        if (ArregloCodigo[i].ToString() == " ")
                        {
                            //Instrucción temporal para guardar el tipo de dato del identificador.
                            string[] ArrSimb = { "PR02", "PR10", "PR14", "PR01", "PR05", "PR06" };

                            for (int x = 0; x < ArrSimb.Length; x++)
                            {
                                if (EDOAC == ArrSimb[x])
                                {
                                    strTipo = Simbolo;
                                }
                            }

                            if (EDOAC == "IDEN")
                            {
                                ID = GuardarSimbolo(Simbolo, strTipo, strValor); //ALMACENA SIMBOLO
                                strTipo = "";
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
                                tokensSem = tokensSem + EDOAC + " ";
                                tokens2 = tokens2 + EDOAC + " ";
                                Tokens = Tokens + EDOAC + " ";
                            }
                        }
                        if (ArregloCodigo[i].ToString() == "\n")
                        {

                            if (EDOAC == "IDEN")
                            {
                                ID = GuardarSimbolo(Simbolo, strTipo, strValor);  //ALMACENA SIMBOLO
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
                        ID = GuardarSimbolo(Simbolo, strValor, strTipo);  //ALMACENA SIMBOLOS
                        tokens2 = tokens2 + EDOAC;
                        Tokens = Tokens + "ID" + ID;
                        foreach (clsSimbolo miSbl in lst)
                        {
                            if (ID == miSbl.Numero)
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

        private void frmLJCR_Load(object sender, EventArgs e)
        {

        }

        bool checkBalanceLLaves(string input)
        {
            int linea = 1;

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == '\n')
                {
                    linea++;
                }

                if (input[i] == '{' || input[i] == '(' || input[i] == '[')
                {
                    // push to stack
                    stack.Push(input[i]);
                }
                else if (input[i] == '}' || input[i] == ')' || input[i] == ']')
                {
                    // pop from stack
                    if (stack.Count == 0 || !isMatchingPair(stack.Pop(), input[i]))
                    {
                        numeroError = linea;
                        return false;
                    }
                }
            }
            numeroError = linea;
            return stack.Count == 0 ? true : false;
        }
        static bool isMatchingPair(char char1, char char2)
        {
            if (char1 == '(' && char2 == ')')
                return true;
            else if (char1 == '{' && char2 == '}')
                return true;
            else if (char1 == '[' && char2 == ']')
                return true;
            else
                return false;
        }

        public void VarDeclarada()
        {
            foreach (clsSimbolo ex in lst)
            {
                if (ex.TipoDeDato == "")
                {
                    rtxErroresSemanticos.Text = rtxErroresSemanticos.Text + "\n" + "VARIABLE NO DECLARADA " + ex.Nombre;
                }
            }
        }
        private void btnSemantico_Click(object sender, EventArgs e)
        {
            if (!(rtxTokens.Lines[0].Contains("PR17") && rtxTokens.Lines[rtxTokens.Lines.Count() - 1].Contains("PR13")))
            {
                rtxErroresSemanticos.Text = rtxErroresSemanticos.Text + "FALTA DE INICIO O FIN EN LA ESTRUCTURA" + "\n";
            }
            VarDeclarada();
            if (!checkBalanceLLaves(rtxCodigoFuente.Text))
            {
                //Falta ver como poder poner el conteo de los errores.

                rtxErroresSemanticos.Text = rtxErroresSemanticos.Text + "\n" + "HUBO ERROR EN LAS LLAVES, PARENTESIS O CORCHETES\n" + "LINEA DEL ERROR: " + numeroError + "\n";
            }

            SqlConnection MiConexion = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            string tokaux = rtxTokens.Text;
            rtxTokens.Text = tokensSem;
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
                    SqlCommand myQuery = new SqlCommand("SELECT PRODUCCION, VALOR, LEN(VALOR) FROM SEMANTICO ORDER BY PRODUCCION DESC, LEN(VALOR) DESC", MiConexion);
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
                                rtxSemantico.Text += segundaCadena + "\n";
                                break;
                            }
                        }
                        if (iteracion > 1000) { /*rtxGramatica.Text += "Linea no aceptada" + "\n"; */bandera = false; break; }

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

            if (rtxTokens.Text.Contains("PR03"))
            {
                if (!(rtxTokens.Text.Contains("PR04") && rtxTokens.Text.Contains("PR26")))
                {
                    rtxErroresSemanticos.Text += "ESTRUCTURA CAMBIA INCOMPLETA" + "\n";
                }
            }
            rtxTokens.Text = tokaux;
            ObtenerERRSEM();

        }
        public void ObtenerERRSEM()
        {

            for (int x = 0; x < rtxSemantico.Lines.Count(); x++)
            {
                if (Mimetodo.ErrorSem(rtxSemantico.Lines[x]) != "")
                {
                    rtxErroresSemanticos.Text += Mimetodo.ErrorSem(rtxSemantico.Lines[x]) + "\n";
                }
            }
        }

        private void btnSintactico_Click(object sender, EventArgs e)
        {
            SqlConnection MiConexion = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
            string tokaux = rtxTokens.Text;
            tokens2 = tokens2.Replace("CONE", "CONS");
            tokens2 = tokens2.Replace("CONF", "CONS");
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
            rtxTokens.Text = tokaux;

        }

        private void btnPosfijo_Click(object sender, EventArgs e)
        {
            posfijo();
        }

        public void LimpiarDatos() {
            rtxCodigoFuente.Text = "";
            rtxErrores.Clear();
            rtxErrores.Update();
            rtxTokens.Text = "";
            lsbSimbolos.Items.Clear();
            lst.Clear();
            rtxGramatica.Clear();
            rtxSemantico.Clear();
            tokensSem = "";
            COID = 0;
            rtxErroresSemanticos.Clear();
        }

        // { }== LLCE [ ] ( ) ; :
        // S LLCE
        public void posfijo()
        {
            string[] operadores = { "OA01", "OA02", "OA03", "OA04", "OA05", "ASIG" };
            string Opersave = "", CadenaSec = "", TokenEnLinea = "", Asignacion = "", Posfijo = "";
            char[] arregloLinea;
            for (int x = 0; x < rtxTokens.Lines.Count(); x++)
            {
                if (rtxTokens.Lines[x].Contains("ASIG"))
                {
                    arregloLinea = rtxTokens.Lines[x].ToCharArray();
                    for (int i = 0; i < arregloLinea.Length; i++)
                    {
                        if (arregloLinea[i].ToString() != " ")
                        {
                            TokenEnLinea += arregloLinea[i].ToString();
                        }
                        else
                        {
                            if (operadores.Contains(TokenEnLinea))
                            {
                                if (TokenEnLinea == "ASIG")
                                {
                                    if (Asignacion == "")
                                    {
                                        Asignacion = "ASIG";
                                        TokenEnLinea = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("altiro hay dos iguales");
                                    }
                                }
                                else
                                {
                                    Opersave = TokenEnLinea;
                                    TokenEnLinea = "";
                                }
                            }
                            else
                            {
                                CadenaSec += TokenEnLinea + " ";
                                if (Opersave != "")
                                {
                                    CadenaSec += Opersave + " ";
                                    Opersave = "";
                                }
                                TokenEnLinea = "";
                            }
                        }
                    }
                    Posfijo += CadenaSec + " " + Asignacion + "\n";
                }

                Asignacion = "";
                CadenaSec = "";
                TokenEnLinea = "";
            }

            rtxPosfijo.Text = Posfijo;
        }

        public void Tripleta()
        {
            if (rtxPosfijo.Text == "") { MessageBox.Show("No se ha realizado el postfijo"); }
            string cadenaOriginal = "", cadenaAux = "", cadenaAux2 = "", TokenEnLinea = "";
            string[] operadores = { "OA01", "OA02", "OA03", "OA04", "OA05", "ASIG" };
            char[] arregloLinea;
            for (int x = 0; x < rtxPosfijo.Lines.Count(); x++)
            {
                cadenaOriginal = rtxPosfijo.Lines[x];
                arregloLinea = cadenaOriginal.ToCharArray();
                for (int i = 0; i < arregloLinea.Length; i++)
                {
                    if (arregloLinea[i].ToString() != " ")
                    {
                        TokenEnLinea += arregloLinea[i].ToString();
                    }
                    else
                    {
                        cadenaAux = cadenaAux + TokenEnLinea + " ";
                        if (operadores.Contains(TokenEnLinea))
                        {
                            char[] arregloLinea2;
                            arregloLinea2 = cadenaAux.ToCharArray();
                            int espacio = 0;
                            for(int y = arregloLinea2.Length -1 ; y >= 0; y--)
                            {
                                if (y==0)
                                {
                                    //Terminar tabla y rtxt de  ensamblador
                                    llenarObjeto(cadenaAux2);
                                }
                                if (arregloLinea[y].ToString() != " ")
                                {
                                    TokenEnLinea = arregloLinea[y].ToString() + TokenEnLinea;
                                }
                                else
                                {
                                    cadenaAux2 = TokenEnLinea + cadenaAux2;
                                    espacio++;
                                    if(espacio == 3)
                                    {
                                  
                                        //Llenar tabla y rtxt de ensamblador
                                        llenarObjeto(cadenaAux2);

                                    }
                                    
                                }
                            }
                        }
                    }
                }
                Temporal++;
            }
        }
        public void llenarObjeto(String CadenaAux2)
        {
            char[] ArregloAux2;

            Tupla miTupla = new Tupla();
            if (CadenaAux2.Contains("TE" + Temporal.ToString()))
            {
                ///
                int Saltos = 0;
                ArregloAux2 = CadenaAux2.ToCharArray();
                for (int i = 0; i < ArregloAux2.Length; i++)
                {
                    if (ArregloAux2[i].ToString() != " ")
                    {
                        switch (Saltos)
                        {
                            case 0:
                                miTupla.DatoObjeto += ArregloAux2[i].ToString();
                                break;
                            case 1:
                                miTupla.DatoFuente += ArregloAux2[i].ToString();
                                break;
                            case 2:
                                miTupla.Operador += ArregloAux2[i].ToString();
                                break;
                        }
                    }
                    else
                    {
                        Saltos++;
                    }
                   
                }
                listTuplas.Add(miTupla);
            }
            else
            {
                miTupla.DatoObjeto = "TE" + Temporal.ToString();
                miTupla.Operador = "ASIG";
                ArregloAux2 = CadenaAux2.ToCharArray();
                string datFuente = "";
                for (int i = 0; i < ArregloAux2.Length; i++)
                {
                    if (ArregloAux2[i].ToString() != " ")
                    {
                        datFuente += ArregloAux2[i].ToString();
                    }
                    miTupla.DatoFuente = datFuente;
                    CadenaAux2.Replace(datFuente, "TE" + Temporal.ToString());
                    listTuplas.Add(miTupla);
                    llenarObjeto(CadenaAux2);
                }
            }
        } 
    }
}
