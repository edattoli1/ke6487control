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

namespace ke6487control
{
    public partial class Form1 : Form
    {
        
        private int GPIBaddress = 22;
        private Device device;

        public Form1()
        {
            InitializeComponent();



        }

        private void startGPIBbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Convert the Secondary Address Combo Text into a number.
                int currentSecondaryAddress = 0;
                int boardId = 0;

                // Intialize the device
                device = new Device(boardId, (byte)GPIBaddress, (byte)currentSecondaryAddress);
                //SetupControlState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            string stringToWrite = "*idn?\n";

            //Write to Device
            try
            {
                device.Write(ReplaceCommonEscapeSequences(stringToWrite));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            string stringRead;

            //Read from Device
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringRead = InsertCommonEscapeSequences(device.ReadString());
                gpibReadBox.Text = stringRead;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }

        private string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

    }
}
