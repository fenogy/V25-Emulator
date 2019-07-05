using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace V25Emulator
{
	/// <summary>
	/// Summary description for KentechSettings.
	/// </summary>
	public class SettingsForm : System.Windows.Forms.Form
	{
		#region Local Variables
		public string configFilePath = "SystemConfig.ctm";
        private DBManager dbMgr ;
		private RS232Settings commSettings;
		
		#endregion

		#region Designer Genarated Variables

        private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
		#endregion
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#region Constructor
		public SettingsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.propertyGrid1);
            this.groupBox2.Location = new System.Drawing.Point(8, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 298);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid1.Location = new System.Drawing.Point(8, 16);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(480, 256);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSave.Location = new System.Drawing.Point(344, 316);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(427, 316);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AWGSettingsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(512, 344);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AWGSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Communication Settings";
            this.Load += new System.EventHandler(this.AWGSettings_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		#region Properties
		
		#endregion
		#region Events
        private void AWGSettings_Load(object sender, System.EventArgs e)
		{
            dbMgr = new DBManager();

            if (dbMgr.OpenConfig(configFilePath))
			{
				// read last configuration
              	SetRS232Settings();
					
			}
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
            this.Close();
		}
		
		private void buttonSave_Click(object sender, System.EventArgs e)
		{   
			dbMgr.UpdateRS232Settings(commSettings.ToArray());

            dbMgr.SaveConfig();
            this.Close(); 
		}
		
		#endregion

		#region Methods

		#region Public 
		
		#endregion

		#region Private
		
		
		private void SetRS232Settings() 
		{
			object[] settings;
			settings = dbMgr.ReadRS232Config();
			if(settings != null)
			{
				commSettings = new RS232Settings(settings);
			}
			else
			{
				commSettings = new RS232Settings();
			}
			propertyGrid1.SelectedObject = commSettings;
		}
	
		#endregion
		#endregion
		
	}
}
