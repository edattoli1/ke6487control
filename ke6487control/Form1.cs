using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.NI4882;

namespace Ke648x
{
    public partial class Form1 : Form
    {

        Ke648xControl pAmm;

        public Form1()
        {
            InitializeComponent();
            pAmm = new Ke648xControl();


        }

        private void startGPIBbutton_Click(object sender, EventArgs e)
        {
            
            pAmm.InitSession();
            string stringRead = pAmm.GetIdentString();

            gpibReadBox.Text = stringRead;
            

        }


        private void initDeviceButton_Click(object sender, EventArgs e)
        {
            pAmm.InitDevice();

        }

    }
}
