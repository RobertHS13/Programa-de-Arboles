using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace Programa_de_Arboles.sol.analizador
{
    class GramaticaCadena : Grammar
    {
        public GramaticaCadena() : base(caseSensitive: false)
        {
            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "-?[0-9]+(\\?[0-9])?");
            RegexBasedTerminal numerodecimal = new RegexBasedTerminal("decimanl", "[0-9]+[.][0-9]+");
            CommentTerminal cadena = new CommentTerminal("string", "\"", ".", "\""); // es una cadena String
            CommentTerminal r_char = new CommentTerminal("caracteres", "'", ".", "'"); // es un caracter char

            #region No Terminales
            var mas = ToTerm("+");
            NonTerminal S = new NonTerminal("S"),
            SUMACADENA = new NonTerminal("SUMACADENA");
            #endregion

            #region Gramatica
            //Gramatica ambigua:
            S.Rule = SUMACADENA;
            SUMACADENA.Rule = cadena;
                /* cadena + mas + cadena
                | cadena + mas + numero
                | numero + mas + cadena
                | cadena + mas + numerodecimal
                | numerodecimal + mas + cadena
                | cadena + mas + r_char
                | r_char + mas + cadena;*/
            #endregion

            #region Preferencias
            this.Root = S;
            #endregion
        }
    }
}