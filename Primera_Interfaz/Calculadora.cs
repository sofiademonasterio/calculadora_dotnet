using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primera_Interfaz;

namespace NCalculadora
{
    internal class Calculadora
    {
        //Constructor
        public Calculadora()
        {
            primerOperador = "";
            segundoOperador = "";
            resultado = "";
            operando = null;
        }

        //Propiedades
        private string primerOperador;
        private string segundoOperador;
        private OperandoDelegate? operando;
        private string resultado;

        //Getter-setter
        public string PrimerOperador { get => primerOperador; set => primerOperador = value; }
        public string SegundoOperador { get => segundoOperador; set => segundoOperador = value; }
        internal OperandoDelegate? Operando { get => operando; set => operando = value; }
        public string Resultado { get => resultado; set => resultado = value; }

        //Metodos estaticos para pasarse por valor afuera
        public static double Suma(double x, double y) { return x + y; }
        public static double Resta(double x, double y) { return x - y; }
        public static double Multiplicacion(double x, double y) { return x * y; }
        public static double Division(double x, double y) {
            if (y == 0) return 0;
            return x / y; 
        }

        //Metodos de la clase no estaticos
        public void CalcularOperacion()
        {
            if (operando != null && segundoOperador != "")
            {
                resultado = $"{operando(double.Parse(primerOperador), double.Parse(SegundoOperador))}";
            }
        }
    }
}
