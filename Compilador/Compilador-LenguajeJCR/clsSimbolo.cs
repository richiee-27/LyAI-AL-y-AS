using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_LenguajeJCR
{
    class clsSimbolo: IEquatable<clsSimbolo>
    {
		private int _intNumero;

		public int Numero
		{
			get { return _intNumero; }
			set { _intNumero = value; }
		}

		private string _strNombre;

		public string Nombre
		{
			get { return _strNombre; }
			set { _strNombre = value; }
		}

		public bool Equals (clsSimbolo OtroObjeto)
		{
			return (this.Nombre == OtroObjeto.Nombre);
		}

		public override string ToString()
		{
			return this.Numero + "\t" + this.Nombre;
		}




	}
}
