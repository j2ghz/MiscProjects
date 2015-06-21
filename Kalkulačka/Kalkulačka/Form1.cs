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
        string Operace;
        bool ZobrazenVysledek = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCislo_Click(object sender, EventArgs e)
        {
            string ButtonTag = "";
            ButtonTag = ((Button)sender).Tag.ToString();
            if (label1.Text.Split().Length < 12)
            {
                if (label1.Text == "0" || ZobrazenVysledek) label1.Text = "";
                if (label1.Text.Contains(",") && ButtonTag == ",") return;
                label1.Text += ButtonTag;
            }
            ZobrazenVysledek = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            provest();
        }

        private void buttonAkce_Click(object sender, EventArgs e)
        {
            if (ZobrazenVysledek == false && Operace != null)
                provest();
            mezisoucet = double.Parse(label1.Text);
            Operace = ((Button)sender).Tag.ToString();
            ZobrazenVysledek = true;
        }

        private void provest()
        {
            string tisk = "";
            if (mezisoucet != 0)
            {
                tisk += mezisoucet.ToString() + " " + Operace + " " + label1.Text;
            }

            switch (Operace)
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
                case "+":
                    mezisoucet += double.Parse(label1.Text);
                    label1.Text = mezisoucet.ToString();
                    break;
            }
            if (mezisoucet != 0)
            {
                tisk += " = " + label1.Text;
                listBox1.Items.Add(tisk);
            }
            ZobrazenVysledek = true;
            mezisoucet = 0;
            Operace = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            Operace = "";
            mezisoucet = 0;
        }

        private void button16_Click(object sender, EventArgs e)
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

        private void button15_Click(object sender, EventArgs e)
        {
            if (double.Parse(label1.Text) > 0)
                label1.Text = "-" + label1.Text;
            else
                label1.Text = label1.Text.TrimStart('-');

        }
    }
}
