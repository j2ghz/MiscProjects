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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            string ButtonTag;
            int cislo;
            if (!(sender is Button))
                throw new Exception("Volání metody kliknutí bez předání tlačítka");
            else
                ButtonTag = ((Button)sender).Tag.ToString();
            if (int.TryParse(ButtonTag, out cislo))
            {
                //pridat na displej
            }
            else
            {
                switch (ButtonTag) // ktere tlacitko krome cisel
                {
                    case "+":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
