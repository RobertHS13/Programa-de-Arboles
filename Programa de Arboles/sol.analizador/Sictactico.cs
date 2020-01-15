using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using Programa_de_Arboles.sol.controlDOT;

namespace Programa_de_Arboles.sol.analizador
{
    class Sictactico
    {
        public static ParseTreeNode analizar(String cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            return arbol.Root;
        }

        public static ParseTreeNode AnalizarEnteros(String cadena)
        {
            GramaticaNumerosEnteros gramatica = new GramaticaNumerosEnteros();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            return arbol.Root;
        }

        public static ParseTreeNode AnalizarCaracteres(String cadena)
        {
            GramaticaCaracteres gramatica = new GramaticaCaracteres();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            return arbol.Root;
        }

        public static ParseTreeNode AnalizarCadena(String cadena)
        {
            GramaticaCadena gramatica = new GramaticaCadena();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            return arbol.Root;
        }

        public static Image getImage(ParseTreeNode raiz)
        {
            String grafoDOT = ControlDOT.getDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDOT);
            byte[] imageBytes = Convert.FromBase64String(img.ToBase64String());
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            Image imagen = Image.FromStream(ms, true);
            return imagen;
        }

        private static void generarImagen(ParseTreeNode raiz)
        {
            String grafoDOT = ControlDOT.getDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDOT);
            img.Save("AST.png");

        }
    }
}
