using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1
{
    public partial class Form2 : Form
    {
        //εμφανιζω τα πρωτα 10 σκορ
        public Form2(List<string> toponomata, List<float> topscores)
        {
            InitializeComponent();
            if (toponomata.Count >= 10)
            {
                for (int i = 0; i <= 9; i++)
                {
                    label1.Text += toponomata[i] + Environment.NewLine;
                    label2.Text += topscores[i] + Environment.NewLine;
                }
            }
            else
            {
                label1.Text = string.Join(Environment.NewLine, toponomata);
                label2.Text = string.Join(Environment.NewLine, topscores);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
