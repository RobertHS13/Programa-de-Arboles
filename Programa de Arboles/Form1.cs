using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programa_de_Arboles.sol.analizador;
using Irony.Parsing;

namespace Programa_de_Arboles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string expresion = textBox1.Text;
            string car, car2;
            if (rx.Checked)
            {
                car = "x";
                car2 = tx.Text;
                expresion = expresion.Replace(car, car2);
            }

            if (ry.Checked)
            {
                car = "y";
                car2 = ty.Text;
                expresion = expresion.Replace(car, car2);
            }

            if (rz.Checked)
            {
                car = "z";
                car2 = tz.Text;
                expresion = expresion.Replace(car, car2);
            }

            //ParseTreeNode resultado = Sictactico.analizar(expresion);
            ParseTreeNode resultado = Sictactico.AnalizarEnteros(expresion);
            //ParseTreeNode resultado = Sictactico.AnalizarCaracteres(expresion);
            //&& expresion.Length == 3
            //ParseTreeNode resultado = Sictactico.AnalizarCadena(expresion);
            if (resultado != null)
            {
                textBox2.Text = "La cadena es correcta";
                pictureBox1.Image = Sictactico.getImage(resultado);
                Recorrido.resolverOperacion(resultado);
            }
            else
            {
                textBox2.Text = "La cadena es incorrecta";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}