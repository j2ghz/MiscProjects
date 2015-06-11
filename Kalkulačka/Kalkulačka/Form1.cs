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
        double mezisoucet;
        string posledniOperace;
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
                throw new ArgumentException("Volání metody kliknutí na tlačítko bez předání tlačítka. !(sender is Button)");
            else
                ButtonTag = ((Button)sender).Tag.ToString();
            if (int.TryParse(ButtonTag, out cislo) && label1.Text.Split().Length < 12) //Stisknute tlacitko je cislo, pridat na display
            {
                if (label1.Text == "0") label1.Text = "";
                label1.Text += ButtonTag;
            }
            else // tlacitko je operace, TODO
            {
                switch (ButtonTag)
                {
                    case "=":
                        provest();
                        break;
                    default:
                        //Displej = 0;
                        if (!(posledniOperace == null))
                        {
                            provest();
                            posledniOperace = null;
                        }
                        posledniOperace = ButtonTag;
                        break;
                }
            }
        }
        private void provest()
        {
            switch (posledniOperace)
            {
                case "+":
                    break;
                default:
                    break;
            }
        }
    }
}
