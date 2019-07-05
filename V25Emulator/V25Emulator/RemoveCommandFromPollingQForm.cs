using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace V25Emulator
{
    public partial class RemoveCommandFromPollingQForm : Form
    {
        #region Variables
        private ArrayList pollingList = new ArrayList();

        #endregion

        #region Constructor
        public RemoveCommandFromPollingQForm()
        {
            InitializeComponent();
            listViewCaptureQ.View = View.Details;
        }

        #endregion

        #region Methods
        private void RemoveCommandFromPollingQForm_Load(object sender, EventArgs e)
        {
            InitializeData();
        }

        private string DecimalToBase(int iDec, int numbase)
        {
            const int base10 = 10;
            char[] cHexa = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            int[] iHexaNumeric = new int[] { 10, 11, 12, 13, 14, 15 };
            int[] iHexaIndices = new int[] { 0, 1, 2, 3, 4, 5 };
            const int asciiDiff = 48;
            string strBin = "";
            int[] result = new int[32];
            int MaxBit = 32;
            for (; iDec > 0; iDec /= numbase)
            {
                int rem = iDec % numbase;
                result[--MaxBit] = rem;
            }
            for (int i = 0; i < result.Length; i++)
                if ((int)result.GetValue(i) >= base10)
                    strBin += cHexa[(int)result.GetValue(i) % base10];
                else
                    strBin += result.GetValue(i);
            strBin = strBin.TrimStart(new char[] { '0' });
            return strBin;
        }

        private void InitializeData()
        {
            for (int j = 0; j < pollingList.Count; j ++ )
            {
                string packet = listViewCaptureQ.Items.Count.ToString();
                ListViewItem item = new ListViewItem(packet, 0);

                byte[] data = (byte []) pollingList[j];
                item.SubItems.Add(DecimalToBase((int)data[0], 16));
                item.SubItems.Add(DecimalToBase((int)data[1], 16));
                //item.SubItems.Add(data[2].ToString());
                string dataString = "";
                for (int i = 2; i < data.Length; i++)
                {
                    dataString += " " + DecimalToBase((int)data[i], 16);
                }
                item.SubItems.Add(dataString);
                listViewCaptureQ.Items.Add(item);
             }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewCaptureQ.SelectedItems.Count > 0)
                listViewCaptureQ.SelectedItems[0].Remove();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            pollingList.Clear();
            for(int i = 0 ; i < listViewCaptureQ.Items.Count ; i++)
            {
                int subItemsCount = listViewCaptureQ.Items[i].SubItems.Count;
                string dataString = listViewCaptureQ.Items[i].SubItems[subItemsCount - 1].Text;
                string[] data = dataString.Split(new char[] { ' ' });
                byte[] cmd = new byte[subItemsCount + data.Length - 3];
                
                for (int j = 1; j < listViewCaptureQ.Items[i].SubItems.Count-1; j++)
                {
                    cmd[j - 1] = Convert.ToByte(Convert.ToInt32(listViewCaptureQ.Items[i].SubItems[j].Text,16));
                }

                for (int j = 0; j < data.Length - 1; j++)
                {
                    cmd[j + 2] = Convert.ToByte(Convert.ToInt32(data[j+1],16));
                }
                pollingList.Add(cmd);
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Properties

        public ArrayList PollingList
        {
            set
            {
                pollingList = value;
            }
            get
            {
                return pollingList;
            }
        }
        #endregion
       
    }
}