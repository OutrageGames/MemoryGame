using Exercise1;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Exercise1
{
    public class Systhma
    {
        public Systhma(PictureBox picture, string picname, int chosen, int nchosen)
        {
            
            var form = Application.OpenForms.OfType<Form1>().First();
            //αν η εικονα ειναι μαυρη
            if (picture.ImageLocation == "black.jpeg" && form.timer1.Enabled == false && form.started == true)
            {
                //αν ειναι αρτιος αριθμος οι μαυρες εικονες
                if (form.closed % 2 == 0)
                {
                    //η εικονα ανοιγει προσωρινα
                    picture.ImageLocation = picname;
                    form.closed -= 1;
                    form.chosen = chosen;
                }
                else
                {
                    //αν επιλεξω ιδια εικονα
                    if (form.chosen == chosen)
                    {
                        //η εικονα ανοιγει για παντα
                        picture.ImageLocation = picname;
                        form.closed -= 1;
                        //αν τις εχω ανοιξει ολες
                        if (form.closed == 0)
                        {
                            //το παιχνιδι τελειωνει
                            form.timer2.Enabled = false;
                            form.button3.Visible = true;
                            form.richTextBox1.Visible = true;
                            form.label5.Visible = true;
                            form.button4.Visible = true;
                            form.started = false;
                        }
                    }
                    else
                    {
                        //αν διαλεξω διαφορετικη εικονα κλεινουν και οι 2 μετα απο λιγη ωρα
                        form.nchosen = nchosen;
                        picture.ImageLocation = picname;
                        form.timer1.Enabled = true;
                    }
                    //αυξανω μια κινηση
                    form.Moves += 1;
                    form.label1.Text = form.Moves.ToString();
                }
            }
            else
            {
                //δεν κανω τιποτα
            }

        }

    }
}