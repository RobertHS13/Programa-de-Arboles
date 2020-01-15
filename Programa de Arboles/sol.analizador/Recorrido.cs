using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;

namespace Programa_de_Arboles.sol.analizador
{
    class Recorrido
    {
        public static void resolverOperacion(ParseTreeNode root)
        {
            //MessageBox.Show("El resultado es: " + Convert.ToInt32(ExpresionEnteros(root.ChildNodes.ElementAt(0))));
            //MessageBox.Show("El resultado es: " + expresion(root.ChildNodes.ElementAt(0)));
        }

        public static Double ExpresionEnteros(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 1:
                    String[] numero = root.ChildNodes.ElementAt(0).ToString().Split(' ');
                    return Convert.ToDouble(numero[0]);
                case 3:
                    switch (root.ChildNodes.ElementAt(1).ToString().Substring(0, 1))
                    {
                        case "+":
                            return ExpresionEnteros(root.ChildNodes.ElementAt(0)) + ExpresionEnteros(root.ChildNodes.ElementAt(2));
                        case "-":
                            return ExpresionEnteros(root.ChildNodes.ElementAt(0)) - ExpresionEnteros(root.ChildNodes.ElementAt(2));
                        case "*":
                            return ExpresionEnteros(root.ChildNodes.ElementAt(0)) * ExpresionEnteros(root.ChildNodes.ElementAt(2));
                        case "/":
                            return ExpresionEnteros(root.ChildNodes.ElementAt(0)) / ExpresionEnteros(root.ChildNodes.ElementAt(2));
                        case "^":
                            return Math.Pow(ExpresionEnteros(root.ChildNodes.ElementAt(0)), ExpresionEnteros(root.ChildNodes.ElementAt(2)));
                        default:
                            return ExpresionEnteros(root.ChildNodes.ElementAt(1));
                    }
            }
            return 0;
        }

        public static Double expresion(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 1:
                    String[] numero = root.ChildNodes.ElementAt(0).ToString().Split(' ');
                    return Convert.ToDouble(numero[0]);
                case 3:
                    switch(root.ChildNodes.ElementAt(1).ToString().Substring(0, 1))
                    {
                        case "+":
                            return expresion(root.ChildNodes.ElementAt(0)) + expresion(root.ChildNodes.ElementAt(2));
                        case "-":
                            return expresion(root.ChildNodes.ElementAt(0)) - expresion(root.ChildNodes.ElementAt(2));
                        case "*":
                            return expresion(root.ChildNodes.ElementAt(0)) * expresion(root.ChildNodes.ElementAt(2));
                        case "/":
                            return expresion(root.ChildNodes.ElementAt(0)) / expresion(root.ChildNodes.ElementAt(2));
                        case "^":
                            return Math.Pow(expresion(root.ChildNodes.ElementAt(0)), expresion(root.ChildNodes.ElementAt(2)));
                        default:
                            return expresion(root.ChildNodes.ElementAt(1));
                    }
            }
            return 0.0;
        }

        /*public static char ExpresionCaracteres(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 1:
                    String[] numero = root.ChildNodes.ElementAt(0).ToString().Split(' ');
                    return Convert.ToDouble(numero[0]);
                case 3:
                    switch (root.ChildNodes.ElementAt(1).ToString().Substring(0, 1))
                    {
                        case "+":
                            return expresion(root.ChildNodes.ElementAt(0)) + expresion(root.ChildNodes.ElementAt(2));
                        case "-":
                            return expresion(root.ChildNodes.ElementAt(0)) - expresion(root.ChildNodes.ElementAt(2));
                        case "*":
                            return expresion(root.ChildNodes.ElementAt(0)) * expresion(root.ChildNodes.ElementAt(2));
                        case "/":
                            return expresion(root.ChildNodes.ElementAt(0)) / expresion(root.ChildNodes.ElementAt(2));
                        case "^":
                            return Math.Pow(expresion(root.ChildNodes.ElementAt(0)), expresion(root.ChildNodes.ElementAt(2)));
                        default:
                            return expresion(root.ChildNodes.ElementAt(1));
                    }
            }
            return 0.0;
        }*/
    }
}
