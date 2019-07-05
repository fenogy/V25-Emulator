using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace V25Emulator
{
    public partial class AddToShortcutForm : Form
    {
        public AddToShortcutForm()
        {
            InitializeComponent();
        }

        #region Properties

        public int SelectedButtonIndex
        {
            get
            {
                return comboBoxButton.SelectedIndex;
            }
        }

        public string ButtonText
        {
            get
            {
                return textBoxButtonText.Text;
            }

        }
        #endregion

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddToShortcutForm_Load(object sender, EventArgs e)
        {
            comboBoxButton.SelectedIndex = 0;
        }
    }
}