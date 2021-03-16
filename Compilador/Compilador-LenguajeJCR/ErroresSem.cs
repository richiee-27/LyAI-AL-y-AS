using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_LenguajeJCR
{
    class ErroresSem
    {
        private string _strError;

        public string Error
        {
            get { return _strError; }
            set { _strError = value; }
        }

        private string _strNombreError;

        public string NombreError
        {
            get { return _strNombreError; }
            set { _strNombreError = value; }
        }


    }
}
