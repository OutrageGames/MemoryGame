using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1
{
    class Start
    {
        public Start()
        {
            var form = Application.OpenForms.OfType<Form1>().First();

            form.started = true;
            form.button1.Visible = false;
            form.timer2.Enabled = true;
            form.button5.Visible = false;
            form.button4.Visible = false;
            form.button6.Visible = false;
        }
    }
}
