using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Compilador_LenguajeJCR
{
    class MetodoConexion
    {
        SqlConnection cnn = new SqlConnection("Data Source=PAVILION-PC;Initial Catalog=Compilador;User ID=sa;Password=pacheco2020");
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter sqlDA;

        public string Recorrer(char[] miArreglo, int intEdo, int indice)
        {
            cnn.Open();

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
            cnn.Open();

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
            cnn.Open();

            cmd.CommandText = "SELECT TOKEN FROM Matriz WHERE EDO = " + edo;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dt);
            cnn.Close();

            return dt.Rows[0]["TOKEN"].ToString();
        }

        public string RecorrerMin(char[] miArreglo, int intEdo, int indice, string Query)
        {
            //Este metodo se manda a llamar solamente cuando se traten de mayúsculas.
            cnn.Open();


            cmd.CommandText = "SELECT " + Query + miArreglo[indice].ToString() + "]" + " FROM Matriz WHERE EDO = " + intEdo;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dt);
            cnn.Close();

            if (Query == "[s ")
                return dt.Rows[0]["s " + miArreglo[indice].ToString()].ToString();
            else
                return dt.Rows[0]["s" + miArreglo[indice].ToString()].ToString();

        }
    }
}
