using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AODPSo.Properties;

namespace AODPSo
{
	public partial class MeterForm : Form
	{
		public string labelText
		{
			get
			{
				return this._labelText;
			}
			set
			{
				this._labelText = value;
				this.updateLabelText(this._labelText);
			}
		}

        public Label pubLabel
        {
            get { return label1; }
        }

		public MeterForm()
		{
			this.InitializeComponent();
		    label1.Text = "just passing";
		}

		private void Mload(object sender, EventArgs e)
		{
		}

		private void updateLabelText(string newText)
		{
			if (this.label1.InvokeRequired)
			{
				MeterForm.updateLabelTextDelegate del = new MeterForm.updateLabelTextDelegate(this.updateLabelText);
				this.label1.Invoke(del, new object[]
				{
					newText
				});
				return;
			}
			this.label1.Text = newText;
		}

		private string _labelText;

		private delegate void updateLabelTextDelegate(string newText);
	}
}
