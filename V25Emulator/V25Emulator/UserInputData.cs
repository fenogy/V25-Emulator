using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace V25Emulator
{
    public partial class UserInputData : UserControl
    {
        public UserInputData()
        {
            InitializeComponent();
        }

        public string LabelName
        {
            set
            {
                lblDataName.Text = value;
            }
            get
            {
                return lblDataName.Text;
            }
        }
        public string TextBoxData
        {
            set
            {
                if (value !="")
                {
                    numericUpDownData.Value = Convert.ToDecimal(value);
                }
                else
                {
                    numericUpDownData.Value = 0;
                }
            }
            get
            {
                return numericUpDownData.Value.ToString();
            }
        }
        public bool HexEnable
        {
            set
            {
                numericUpDownData.Hexadecimal = value;
            }
            get
            {
                return numericUpDownData.Hexadecimal;
            }
        }
    }
}
