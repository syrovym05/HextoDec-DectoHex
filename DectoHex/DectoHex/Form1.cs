using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DectoHex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            listBox1.Items.Add(DectoHex(n));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(HextoDec((textBox2.Text)));
        }


        public string DectoHex(int i)
        {
            StringBuilder vys = new StringBuilder();

            while (i > 0)
            {
                string cislo = (i % 16).ToString();

                if ((i % 16) > 9)
                {
                    cislo = ((char)((i % 16) + 55)).ToString();
                }

                vys.Insert(0, cislo);
                i /= 16;
            }

            return vys + "";
        }


        public int HextoDec(string s)   //47E
        {
            int vys = 0;

            for (int i = 0; i < s.Length; i++)
            {
                 int znak = (s[i] - '0');
                 if (znak > 9) znak = znak - 7;
                
                 vys += (int)(Math.Pow(16, s.Length - i - 1) * znak);
               
            }
                        
            return vys;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

       

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'A' || e.KeyChar > 'F') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }   

}


