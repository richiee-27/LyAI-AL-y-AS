using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador_LenguajeJCR
{
    class Archivos
    {
        public void CargarArchivo(RichTextBox rtxCodigoFuente)
        {
            //Función para cargar el archivo de texto 
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Documents | *.txt";
            open.Title = "Cargar Archivo";
            open.Filter = "";
            var o = open.ShowDialog();
            if (o == DialogResult.OK)
            {
                StreamReader read = new StreamReader(open.FileName);
                rtxCodigoFuente.Text = read.ReadToEnd();
                read.Close();
            }
        }

        public void GuardarArchivo(RichTextBox rtxCodigoFuente)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.FileName = "*.txt";
            sfd.DefaultExt = "txt";
            sfd.Filter = "txt files (*.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream filestream = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(filestream);

                sw.Write(rtxCodigoFuente.Text);
                sw.Close();
                filestream.Close();
            }
        }

        public void GuardarTokens(RichTextBox rtxCodigoFuente, RichTextBox rtxTokens)
        {
            string nombreArchivoCodigo = "";

            SaveFileDialog guardar = new SaveFileDialog();
            if (nombreArchivoCodigo != "")
            {
                guardar.FileName = nombreArchivoCodigo;
                guardar.Title = nombreArchivoCodigo;
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in rtxCodigoFuente.Lines)
                {
                    escribir.WriteLine(line);
                }
                escribir.Close();
                MessageBox.Show("Archivo modificado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            guardar.Filter = "documento de texto|*.txt";
            guardar.Title = "GUARDAR";
            guardar.FileName = "Sin titulo";
            var resultado = guardar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in rtxTokens.Lines)
                {
                    escribir.WriteLine(line);
                }
                escribir.Close();
            }
        }

        public void AlmacenarSimbolos(RichTextBox rtxCodigoFuente, ListBox lsbSimbolos)
        {
            string nombreArchivoCodigo = "";
            SaveFileDialog guardar = new SaveFileDialog();
            if (nombreArchivoCodigo != "")
            {
                guardar.FileName = nombreArchivoCodigo;
                guardar.Title = nombreArchivoCodigo;
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in rtxCodigoFuente.Lines)
                {
                    escribir.WriteLine(line);
                }
                escribir.Close();
                MessageBox.Show("Archivo modificado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            guardar.Filter = "documento de texto|*.txt";
            guardar.Title = "GUARDAR";
            guardar.FileName = "Sin titulo";
            var resultado = guardar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in lsbSimbolos.Items)
                {
                    escribir.WriteLine(line);
                }
                escribir.Close();
            }
        }
        public void ArchivoEnsambler(RichTextBox rtxCodigoFt,string ruta)
        {

            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.FileName = ruta;
                StreamReader read = new StreamReader(open.FileName);
                rtxCodigoFt.Text = read.ReadToEnd();
                read.Close();
                

            }
            catch(Exception x)
            {

            }
        }
    }
    
}
