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
        double mezisoucet = 0;
        string posledniOperace;
        bool Vyprazdnit = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void button_Click(object sender, EventArgs e)
        //{
        //    string ButtonTag = "";
        //    int cislo;
        //    if (!(sender is Button))
        //        throw new ArgumentException("Volání metody kliknutí na tlačítko bez předání tlačítka. !(sender is Button)");
        //    else
        //        ButtonTag = ((Button)sender).Tag.ToString();
        //    if (int.TryParse(ButtonTag, out cislo) && label1.Text.Split().Length < 12) //Stisknute tlacitko je cislo, pridat na display
        //    {
        //        if (label1.Text == "0") label1.Text = "";
        //        label1.Text += ButtonTag;
        //    }
        //    else // tlacitko je operace, TODO
        //    {
        //        switch (ButtonTag)
        //        {
        //            case "=":
        //                provest();
        //                break;
        //            default:
        //                //Displej = 0;
        //                if (!(posledniOperace == null))
        //                {
        //                    provest();
        //                    posledniOperace = null;
        //                }
        //                posledniOperace = ButtonTag;
        //                break;
        //        }
        //    }
        //}
        private void buttonCislo_Click(object sender, EventArgs e)
        {
            if (Vyprazdnit)
                label1.Text = "";
            string ButtonTag = "";
            if (!(sender is Button))
                throw new ArgumentException("Volání metody kliknutí na tlačítko bez předání tlačítka. !(sender is Button)");
            else
                ButtonTag = ((Button)sender).Tag.ToString();
            if (label1.Text.Split().Length < 12)
            {
                if (label1.Text == "0") label1.Text = "";
                label1.Text += ButtonTag;
            }
            Vyprazdnit = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (Vyprazdnit)
                label1.Text = "0";
            switch (posledniOperace)
            {
                case "-":
                    mezisoucet -= double.Parse(label1.Text);
                    label1.Text = mezisoucet.ToString();
                    break;
                case "*":
                    mezisoucet *= double.Parse(label1.Text);
                    label1.Text = mezisoucet.ToString();
                    break;
                case "/":
                    mezisoucet /= double.Parse(label1.Text);
                    label1.Text = mezisoucet.ToString();
                    break;
                default:
                    mezisoucet += double.Parse(label1.Text);
                    label1.Text = mezisoucet.ToString();
                    break;
            }
            if (sender != null)
                listBox1.Items.Add(label1.Text + " =");
            posledniOperace = "";
            Vyprazdnit = true;
        }

        private void buttonAkce_Click(object sender, EventArgs e)
        {
            button20_Click(null, null);
            listBox1.Items.Add(label1.Text + " " + ((Button)sender).Tag.ToString());
            posledniOperace = ((Button)sender).Tag.ToString(); //mozna dat vse do jedne
        }

        private void button17_Click(object sender, EventArgs e)
        {
            switch (label1.Text.Length)
            {
                case 0:
                    throw new Exception("Na displeji by nemělo být prázdno");
                case 1:
                    label1.Text = "0";
                    break;
                default:
                    label1.Text = label1.Text.Remove(label1.Text.Length - 1);
                    break;
            }
                
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            posledniOperace = "";
        }
    }
}
