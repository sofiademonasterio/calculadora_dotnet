using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NCalculadora;

namespace Primera_Interfaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock? resultado;
        TextBlock? contenido;
        Calculadora calculadora = new Calculadora();
        public MainWindow()
        {
            InitializeComponent();
            resultado = FindName(name: "Resultado") as TextBlock;
            contenido = FindName(name: "Contenido") as TextBlock;

        }

        //Boton de los numeros
        private void Button_Number(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (calculadora.Operando == null)
            {
                calculadora.PrimerOperador = calculadora.PrimerOperador + btn.Content;
                contenido.Text = calculadora.PrimerOperador;
            }
            else
            {
                calculadora.SegundoOperador += btn.Content;

                contenido.Text += calculadora.SegundoOperador;
            }
                
        }
        
        //Boton de los operando
         private void Button_Operando(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (calculadora.Operando != null)
            {
                calculadora.SegundoOperador = "";
                calculadora.PrimerOperador = calculadora.Resultado;
            }
                switch ($"{btn.Content}")
                {
                    case "+":
                        calculadora.Operando = Calculadora.Suma;
                        contenido.Text += "+";
                        break;
                    case "-":
                        calculadora.Operando = Calculadora.Resta;
                        contenido.Text += "-";
                        break;
                    case "*":
                        calculadora.Operando = Calculadora.Multiplicacion;
                        contenido.Text += "*";
                        break;
                    case "/":
                        calculadora.Operando = Calculadora.Division;
                        contenido.Text += "/";
                        break;
                }
            }

        //Boton del grid
        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            calculadora.CalcularOperacion();
            resultado.Text = calculadora.Resultado;
        }
    }
    delegate double OperandoDelegate(double x, double y);
}
