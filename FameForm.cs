using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AODPSo.Properties;

namespace AODPSo
{
	public partial class FameForm : Form
	{
		public string fText
		{
			get
			{
				return this._fText;
			}
			set
			{
				this._fText = value;
				this.updatefText(this._fText);
			}
		}

	    public Label pubLabel
	    {
	        get { return label1; }
	    }
		public FameForm()
		{
			this.InitializeComponent();
		}

		private void updatefText(string newText)
		{
			if (this.label1.InvokeRequired)
			{
				FameForm.updatefTextDelegate del = new FameForm.updatefTextDelegate(this.updatefText);
				this.label1.Invoke(del, new object[]
				{
					newText
				});
				return;
			}
			this.label1.Text = newText;
		}

		private string _fText;

		private delegate void updatefTextDelegate(string newText);
	}
}
