using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace V25Emulator
{
    public partial class CustomByteData : UserControl
    {
        public CustomByteData()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            comboBoxTag.DataSource = Enum.GetValues(typeof(ByteDataTag));
            comboBoxDataType.DataSource = Enum.GetValues(typeof(DataType));
        }

        #region Properties
        public string DataTag
        {
            set
            {
                comboBoxTag.Text = value;
            }
            get
            {
                return comboBoxTag.Text;
            }
        }
        public string TxtDataDescription
        {
            set
            {
                textBoxDescription.Text = value;
            }
            get
            {
                return textBoxDescription.Text;
            }
        }
        public string DataTypeTag
        {
            set
            {
                comboBoxDataType.Text = value;
            }
            get
            {
                return comboBoxDataType.Text;
            }
        }
        #endregion

    }
}
