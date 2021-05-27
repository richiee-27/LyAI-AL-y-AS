using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_LenguajeJCR
{
    class Tupla
    {
        public string DatoObjeto { get; set; }
        public string DatoFuente { get; set; }
        public string Operador { get; set; }
        public Tupla()
        {

        }
        public Tupla(string DO, string DF, string Op)
        {
            DatoObjeto = DO;
            DatoFuente = DF;
            Operador = Op;
        }

        public override string ToString()
        {
            return DatoObjeto + "\t" + DatoFuente + "\t" + Operador;
        }
    }
}
