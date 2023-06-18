using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exercise1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public int closed { get; set; }
        public int chosen { get; set; }
        public int nchosen { get; set; }
        public int Moves { get; set; }
        public float Time { get; set; }
        public float realScore { get; set; }
        public bool started { get; set; }
        public List<string> arxeia { get; set; }
        public List<Point> theseis { get; set; }
        public List<PictureBox> PictureBoxes { get; set; }

        float scores = 0;
        string names;
        int grammes;
        private List<string> temp;

        private void Form1_Load(object sender, EventArgs e)
        {
            closed = 24;

            button3.Visible = false;
            richTextBox1.Visible = false;
            label5.Visible = false;
            richTextBox2.Visible = false;
            richTextBox3.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button6.Visible = false;

            #region Randomize
            //φτιαχνω λιστα που περιεχει ολα τα pictureboxes
            var PictureBoxes = new List<PictureBox>
            {
                 pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                 pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24
            };

            //φτιαχνω λιστα με τις θεσεις των pictureboxes
            List<Point> theseis = new List<Point>();

            for (int i = 0; i < PictureBoxes.Count(); i++)
            {
                theseis.Add(PictureBoxes[i].Location);
            }

            //ανακατευω λιστα θεσεων
            theseis = theseis.OrderBy(a => Guid.NewGuid()).ToList();

            //θετω ιση τη θεση του καθενος με την ανακατεμενη λιστα 
            for (int i = 0; i < PictureBoxes.Count(); i++)
            {
                PictureBoxes[i].Location = theseis[i];
            }
            #endregion

            #region Scores
            //φορτωνω το αρχειο στο richtextbox3 και αρχικοποιω δυο λιστες
            richTextBox3.LoadFile("Saving.txt", RichTextBoxStreamType.PlainText);

            var toponomata = new List<String> { };
            var topscores = new List<float> { };
            grammes = 0;
            //για καθε γραμμη του textbox προσθετω την 1η και την 2η στηλη στις λιστες toponomata,topscores αντιστοιχα
            foreach (string s in richTextBox3.Lines)
            {
                String[] tmp = s.Split(' ');
                if (tmp[0] == string.Empty)
                {
                    break;
                }

                scores = Convert.ToSingle(tmp[1]);
                names = tmp[0];
                toponomata.Add(names);
                topscores.Add(scores);
                grammes += 1;
            }
            #endregion

            #region takeimages
            //θετω τη λιστα arxeia ιση με τα αρχεια png του φακελου μου
            string localPath = "./";

            arxeia = new List<string>(Directory.EnumerateFiles(localPath, "*.png"));

            //φτιαχνω λιστα που περιεχει ολα τα pictureboxes
            var PictureBoxes2 = new List<PictureBox>
            {
                 pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                 pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24
            };

            //βαζω στα pictureboxes τις εικονες απο τη λιστα arxeia
            for (int i = 0; i < PictureBoxes2.Count(); i++)
            {
                if (i <= 11)
                {
                    PictureBoxes2[i].ImageLocation = arxeia[i];
                }
                else
                {
                    PictureBoxes2[i].ImageLocation = arxeia[i - 12];
                }
            }

            #endregion

            Black2();
        }

        #region allBlack
        //μαυριζω ολες τις εικονες εκτος απο αυτες που εχουν ανοιχτει
        public void allBlack()
        {
            if (chosen == 1 || nchosen == 1)
            {
                pictureBox1.ImageLocation = "black.jpeg";
                pictureBox2.ImageLocation = "black.jpeg";
            }
            if (chosen == 2 || nchosen == 2)
            {
                pictureBox3.ImageLocation = "black.jpeg";
                pictureBox4.ImageLocation = "black.jpeg";
            }
            if (chosen == 3 || nchosen == 3)
            {
                pictureBox5.ImageLocation = "black.jpeg";
                pictureBox6.ImageLocation = "black.jpeg";
            }
            if (chosen == 4 || nchosen == 4)
            {
                pictureBox7.ImageLocation = "black.jpeg";
                pictureBox8.ImageLocation = "black.jpeg";
            }
            if (chosen == 5 || nchosen == 5)
            {
                pictureBox9.ImageLocation = "black.jpeg";
                pictureBox10.ImageLocation = "black.jpeg";
            }
            if (chosen == 6 || nchosen == 6)
            {
                pictureBox11.ImageLocation = "black.jpeg";
                pictureBox12.ImageLocation = "black.jpeg";
            }
            if (chosen == 7 || nchosen == 7)
            {
                pictureBox13.ImageLocation = "black.jpeg";
                pictureBox14.ImageLocation = "black.jpeg";
            }
            if (chosen == 8 || nchosen == 8)
            {
                pictureBox15.ImageLocation = "black.jpeg";
                pictureBox16.ImageLocation = "black.jpeg";
            }
            if (chosen == 9 || nchosen == 9)
            {
                pictureBox17.ImageLocation = "black.jpeg";
                pictureBox18.ImageLocation = "black.jpeg";
            }
            if (chosen == 10 || nchosen == 10)
            {
                pictureBox19.ImageLocation = "black.jpeg";
                pictureBox20.ImageLocation = "black.jpeg";
            }
            if (chosen == 11 || nchosen == 11)
            {
                pictureBox21.ImageLocation = "black.jpeg";
                pictureBox22.ImageLocation = "black.jpeg";
            }
            if (chosen == 12 || nchosen == 12)
            {
                pictureBox23.ImageLocation = "black.jpeg";
                pictureBox24.ImageLocation = "black.jpeg";
            }

        }
        #endregion

        #region BLACK2
        //μαυριζω ολες τις εικονες
        public void Black2()
        {
            pictureBox1.ImageLocation = "black.jpeg";
            pictureBox2.ImageLocation = "black.jpeg";
            pictureBox3.ImageLocation = "black.jpeg";
            pictureBox4.ImageLocation = "black.jpeg";
            pictureBox5.ImageLocation = "black.jpeg";
            pictureBox6.ImageLocation = "black.jpeg";
            pictureBox7.ImageLocation = "black.jpeg";
            pictureBox8.ImageLocation = "black.jpeg";
            pictureBox9.ImageLocation = "black.jpeg";
            pictureBox10.ImageLocation = "black.jpeg";
            pictureBox11.ImageLocation = "black.jpeg";
            pictureBox12.ImageLocation = "black.jpeg";
            pictureBox13.ImageLocation = "black.jpeg";
            pictureBox14.ImageLocation = "black.jpeg";
            pictureBox15.ImageLocation = "black.jpeg";
            pictureBox16.ImageLocation = "black.jpeg";
            pictureBox17.ImageLocation = "black.jpeg";
            pictureBox18.ImageLocation = "black.jpeg";
            pictureBox19.ImageLocation = "black.jpeg";
            pictureBox20.ImageLocation = "black.jpeg";
            pictureBox21.ImageLocation = "black.jpeg";
            pictureBox22.ImageLocation = "black.jpeg";
            pictureBox23.ImageLocation = "black.jpeg";
            pictureBox24.ImageLocation = "black.jpeg";
        }
        #endregion

        public void timer1_Tick(object sender, EventArgs e)
        {
            allBlack();
            closed += 1;
            timer1.Enabled = false;
        }
        #region Pictureboxes_click
        //καλω την ταξη systhma καθε φορα που κανω κλικ στα pictureboxes, με τις αναλογες parameters
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox1, arxeia[0], 1, 1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox2, arxeia[0], 1, 1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox3, arxeia[1], 2, 2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox4, arxeia[1], 2, 2);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox5, arxeia[2], 3, 3);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox6, arxeia[2], 3, 3);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {   
            Systhma systhma = new Systhma(pictureBox7, arxeia[3], 4, 4);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox8, arxeia[3], 4, 4);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox9, arxeia[4], 5, 5);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox10, arxeia[4], 5, 5);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox11, arxeia[5], 6, 6);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox12, arxeia[5], 6, 6);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox13, arxeia[6], 7, 7);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox14, arxeia[6], 7, 7);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox15, arxeia[7], 8, 8);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox16, arxeia[7], 8, 8);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox17, arxeia[8], 9, 9);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox18, arxeia[8], 9, 9);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox19, arxeia[9], 10, 10);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox20, arxeia[9], 10, 10);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox21, arxeia[10], 11, 11);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox22, arxeia[10], 11, 11);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox23, arxeia[11], 12, 12);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Systhma systhma = new Systhma(pictureBox24, arxeia[11], 12, 12);
        }
        #endregion  

        private void button1_Click(object sender, EventArgs e)
        {
            Start start = new Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Time += 0.1f;
            label4.Text = System.Math.Round(Time, 2).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        #region Save
        private void button3_Click(object sender, EventArgs e)
        {
            //υπολογιζω το σκορ και
            //κανω το richtextbox3 ακριβως στη μορφη που θελω και το σωζω στο αρχειο μου
            realScore = (1 / (Moves + Time)) * 100000;

            richTextBox3.LoadFile("Saving.txt", RichTextBoxStreamType.PlainText);

            richTextBox2.Text = realScore.ToString("0.0");
            string sent2 = richTextBox2.Text;
            richTextBox1.Text += " ";
            richTextBox1.AppendText(sent2);

            richTextBox3.Text += Convert.ToString(richTextBox1.Text);
            richTextBox3.Text += "\n";

            richTextBox3.SaveFile("Saving.txt", RichTextBoxStreamType.PlainText);

            var lines = richTextBox3.Text.Split('\n');
            
            
            button3.Visible = false;
            richTextBox1.Visible = false;
            label5.Visible = false;
            label6.Visible = true;
            label7.Text = realScore.ToString("0.0");
            label7.Visible = true;
            button4.Visible = true;
            button6.Visible = true;
        }
        #endregion

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        #region Scores
        public void Showscores()
        {
            //δημιουργω δυο λιστες με τα ονοματα και τα σκορ των παιχτων
            var toponomata = new List<String> { };
            var topscores = new List<float> { };
            grammes = 0;

            foreach (string s in richTextBox3.Lines)
            {
                String[] tmp = s.Split(' ');
                if (tmp[0] == string.Empty)
                {
                    break;
                }

                scores = Convert.ToSingle(tmp[1]);
                names = tmp[0];
                toponomata.Add(names);
                topscores.Add(scores);
                grammes += 1;
            }
            //χρησιμοποιω την τεχνικη bubble sort για να βαλω τα σκορ σε φθινουσα σειρα ωστε να τα εμφανισω στη 2η φορμα μου
            for (int i = 1; i < grammes; i++)
            {
                for (int j = 0; j < grammes - i; j++)
                {
                    if (topscores[j] < topscores[j + 1])
                    {
                        string temp1 = toponomata[j];
                        toponomata[j] = toponomata[j + 1];
                        toponomata[j + 1] = temp1;
                        float temp2 = topscores[j];
                        topscores[j] = topscores[j + 1];
                        topscores[j + 1] = temp2;
                    }
                }
            }

            Form2 frm2 = new Form2(toponomata, topscores);
            frm2.Show();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            Showscores();
        }
        #endregion

        #region putyourimages
        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();

            if (fdb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                temp = new List<string>(Directory.EnumerateFiles(fdb.SelectedPath, "*.png"));

                if (temp.Count == 12)
                {
                    arxeia = temp;
                    MessageBox.Show("Your images are in the game!");
                }
                else if (temp.Count < 12)
                {
                    MessageBox.Show("Sorry, your images are not enough. Try again!");
                }
                else if (temp.Count > 12)
                {
                    arxeia = temp;
                    MessageBox.Show("Your images are too many! Only some of them are in the game.");
                }

                var PictureBoxes2 = new List<PictureBox>
                {
                     pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                     pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24
                };

                for (int i = 0; i < arxeia.Count; i++)
                {

                    PictureBoxes2[i].ImageLocation = arxeia[i];
                    PictureBoxes2[i + 1].ImageLocation = arxeia[i];

                }

                Black2();
            }
            else
            {
                //mhn kaneis tipota
            }
            
            
        }
        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            Restart restart = new Restart();
            button6.Visible = false;
        }

        private void showTop10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Showscores();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (started == false)
            {
                Start start = new Start();
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restart restart = new Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
