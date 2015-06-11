using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulačka
{
    public partial class Form1 : Form
    {
        long displej;
        public long Displej
        {
            get
            {
                return displej;
            }
            set
            {
                displej = value;
                label1.Text = value.ToString();
            }
        }
        long mezisoucet;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            string ButtonTag = "";
            int cislo;
            if (!(sender is Button))
                throw new Exception("Volání metody kliknutí bez předání tlačítka");
            else
                ButtonTag = ((Button)sender).Tag.ToString();
            if (int.TryParse(ButtonTag, out cislo))
            {
                //pridat na displej
                Displej *= 10;
                Displej += cislo;
            }
            else
            {
                switch (ButtonTag) // TODO: operace, to co tu je tak je spatne
                {
                    case "+":
                        listBox1.Items.Add(Displej.ToString() + " +");
                        mezisoucet += displej;
                        displej = 0;
                        break;
                    case "-":
                        break;
                    case "*":
                        break;
                    case "/":
                        break;
                    case "=":
                        listBox1.Items.Add(Displej.ToString() + " =");
                        mezisoucet = 0;
                        displej = 0;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
