namespace V25Emulator
{
    partial class UserInputData
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
            this.lblDataName = new System.Windows.Forms.Label();
            this.numericUpDownData = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDataName
            // 
            this.lblDataName.AutoSize = true;
            this.lblDataName.Location = new System.Drawing.Point(-1, 10);
            this.lblDataName.Name = "lblDataName";
            this.lblDataName.Size = new System.Drawing.Size(30, 13);
            this.lblDataName.TabIndex = 0;
            this.lblDataName.Text = "Data";
            // 
            // numericUpDownData
            // 
            this.numericUpDownData.Location = new System.Drawing.Point(80, 8);
            this.numericUpDownData.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownData.Name = "numericUpDownData";
            this.numericUpDownData.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownData.TabIndex = 2;
            this.numericUpDownData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UserInputData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownData);
            this.Controls.Add(this.lblDataName);
            this.Name = "UserInputData";
            this.Size = new System.Drawing.Size(205, 34);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataName;
        private System.Windows.Forms.NumericUpDown numericUpDownData;
    }
}
