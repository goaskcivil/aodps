namespace AODPSo
{
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lockbutton = new System.Windows.Forms.Button();
            this.logLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "BETA version by BaalEvan and Civil based on [Savage] Tenebria code ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(390, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "In case of emergency contact  reddit: u/goaskcivil , discord: Civil#2137";
            // 
            // label2
            // 
            /*this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "" + */
   // "rs";
            // 
            // lockbutton
            // 
            this.lockbutton.Location = new System.Drawing.Point(12, 12);
            this.lockbutton.Name = "lockbutton";
            this.lockbutton.Size = new System.Drawing.Size(101, 23);
            this.lockbutton.TabIndex = 5;
            this.lockbutton.Text = "Lock Overlay";
            this.lockbutton.UseVisualStyleBackColor = true;
            this.lockbutton.Click += new System.EventHandler(this.lockbutton_Click);
            // 
            // logLabel
            // 
           /* this.logLabel.Location = new System.Drawing.Point(13, 83);
            this.logLabel.Name = "logLabel";
            this.logLabel.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logLabel.Size = new System.Drawing.Size(561, 20);
            this.logLabel.TabIndex = 7; */
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(585, 103);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.lockbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::AODPSo.Properties.Settings.Default, "MainLoc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::AODPSo.Properties.Settings.Default.MainLoc;
            this.Name = "Form1";
            this.Text = "AODPS 0.221c Open Beta";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Button lockbutton;
        private System.Windows.Forms.TextBox logLabel;
    }
}
