//#define K6487
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.NI4882;

// Controls the Keithly 6485 or 6487
// Undefine #define K6487 if you have a 6487 and want to control voltage output


namespace Ke648x
{
    public class Ke648xControl
    {
        private int GPIBaddress = 22;
        private Device device;

        public void InitSession()
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

        }

        public string GetIdentString()
        {
            string stringToWrite = "*idn?";

            //Write to Device
            try
            {
                device.Write(stringToWrite);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            string stringRead = "";

            //Read from Device
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringRead = device.ReadString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            return stringRead;
        }


        // Initalize Keithley picoammeter to default state
        public void InitDevice()
        {
            string initString1 = ":SYST:PRES;:SENS:FUNC 'CURR';:SENS:CURR:RANG 2E-";
            string nplcString = ":SENS:CURR:DC:NPLC ";
            int picoAmmRange = 6;
            double NPLCcycles = 1;

            //reset 6487, set range
            device.Write(initString1 + picoAmmRange.ToString());

            //turn off digital averaging filter
            device.Write(":SENS:AVER:STAT OFF");

            //turn off Zero Check
            device.Write(":SYST:ZCH:STAT OFF");

            //Set up current reporting string on READs from GPIB
            device.Write(":FORM:ELEM READ");

            //turn off Median filter
            device.Write(":SENS:CURR:MED:STAT OFF");

            //set up NPLC (analog filter)
            device.Write(nplcString + NPLCcycles.ToString());

            //set up arm and trace
            device.Write(":ARM:COUNT INF; :TRACE:CLE; :TRACE:POINTS 1; :TRACE:FEED SENS; :TRACE:FEED SENS; :TRACE:FEED:CONT NEXT;"
                 + ":TRIG:COUNT 1");

            #if (K6487)
            
            //set Voltage out range
            device.Write(":SOUR:VOLT:RANG 500");

            //set Voltage out to zero
            device.Write(":SOUR:VOLT 0");

            //turn on Voltage Out
            device.Write(":SOUR:VOLT:STATE ON");
            
            #endif

            //Start measurements
            device.Write(":INIT");
        }

        //private string ReplaceCommonEscapeSequences(string s)
        //{
        //    return s.Replace("\\n", "\n").Replace("\\r", "\r");
        //}

        //private string InsertCommonEscapeSequences(string s)
        //{
        //    return s.Replace("\n", "\\n").Replace("\r", "\\r");
        //}

    }
}
