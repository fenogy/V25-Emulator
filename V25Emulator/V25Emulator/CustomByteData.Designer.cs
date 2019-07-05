namespace V25Emulator
{
    partial class CustomByteData
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxTag = new System.Windows.Forms.ComboBox();
            this.comboBoxDataType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(3, 9);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(136, 20);
            this.textBoxDescription.TabIndex = 2;
            // 
            // comboBoxTag
            // 
            this.comboBoxTag.FormattingEnabled = true;
            this.comboBoxTag.Location = new System.Drawing.Point(178, 8);
            this.comboBoxTag.Name = "comboBoxTag";
            this.comboBoxTag.Size = new System.Drawing.Size(115, 21);
            this.comboBoxTag.TabIndex = 3;
            // 
            // comboBoxDataType
            // 
            this.comboBoxDataType.FormattingEnabled = true;
            this.comboBoxDataType.Location = new System.Drawing.Point(335, 8);
            this.comboBoxDataType.Name = "comboBoxDataType";
            this.comboBoxDataType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDataType.TabIndex = 4;
            // 
            // CustomByteData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxDataType);
            this.Controls.Add(this.comboBoxTag);
            this.Controls.Add(this.textBoxDescription);
            this.Name = "CustomByteData";
            this.Size = new System.Drawing.Size(466, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxTag;
        private System.Windows.Forms.ComboBox comboBoxDataType;

    }
}
