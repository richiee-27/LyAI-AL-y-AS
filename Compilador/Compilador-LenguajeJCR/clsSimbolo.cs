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

		private string strValor;

		public string Valor
		{
			get { return strValor; }
			set { strValor = value; }
		}

		private string strTipoDato;

		public string TipoDeDato
		{
			get { return strTipoDato; }
			set { strTipoDato = value; }
		}


		public bool Equals (clsSimbolo OtroObjeto)
		{
			return (this.Nombre == OtroObjeto.Nombre);
		}

		public override string ToString()
		{
			return this.Numero + "\t" + this.Nombre + "\t" + this.TipoDeDato + "\t" + this.Valor;
		}




	}
}
