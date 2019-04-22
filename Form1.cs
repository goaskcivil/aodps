using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AODPSo.Properties;
using PcapDotNet.Core;
using PcapDotNet.Packets;

namespace AODPSo
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			this.InitializeComponent();
			this.playerHandler = new PlayerHandler(this);
			this.mForm.Show();
			this.fForm.Show();
            //Test Data
//		    this.playerHandler.ClearData();
//		    this.playerHandler.zoneTime = DateTime.Now;
//		    this.playerHandler.AddPlayer("Me", this.playerHandler.self);
//		    this.playerHandler.AddPlayer("Him", 1);
//		    this.playerHandler.AddPlayer("Ho", 2);
//		    this.playerHandler.AddPlayer("Whore", 3);
//		    this.playerHandler.AddPlayer("Civil", 4);
//		    playerHandler.Players[0].dealt = 666;
//		    playerHandler.Players[1].dealt = 444;
//		    playerHandler.Players[0].healed= 999;
//		    playerHandler.Players[0].taken = 777;

//		    this.playerHandler.OutputData();
//		    this.playerHandler.OutputFame();
			try
			{
				this._eventHandler = new PacketHandler(this.playerHandler);
				this.photonPacketHandler = new PhotonPacketHandler(this._eventHandler);
				new Thread(createListener).Start();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
//			    goto Something;
//				while (true)
//				{
//					Something:
//					goto Something;
//				}
			}
			base.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing1);
		}

	    public TextBox LogLabel
	    {
	        get { return logLabel; }
	    }

		private void button1_Click(object sender, EventArgs e)
		{
			this.playerHandler.ClearData();
		}

		private void button2_Click(object sender, EventArgs e)
		{
		}

		private void createListener()
		{
			IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
			if (allDevices.Count == 0)
			{
				MessageBox.Show("No Network Interface Found! Please make sure WinPcap is properly installed.");
				return;
			}
			for (int i = 0; i != allDevices.Count; i++)
			{
				LivePacketDevice device = allDevices[i];
				if (device.Description != null)
				{
					Console.WriteLine(" (" + device.Description + ")");
				}
				else
				{
					Console.WriteLine(" (Unknown)");
				}
			}
			using (List<LivePacketDevice>.Enumerator enumerator = allDevices.ToList<LivePacketDevice>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PacketDevice selectedDevice = enumerator.Current;
					new Thread(() => inEnumerator(selectedDevice)).Start();
				}
			}
		}

	    private void inEnumerator(PacketDevice selectedDevice)
	    {
	        {
	            using (PacketCommunicator communicator = selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
	            {
	                if (communicator.DataLink.Kind != DataLinkKind.Ethernet)
	                {
	                    Console.WriteLine("This program works only on Ethernet networks.");
	                }
	                else
	                {
	                    using (BerkeleyPacketFilter filter = communicator.CreateFilter("ip and udp"))
	                    {
	                        communicator.SetFilter(filter);
	                    }

	                    Console.WriteLine("Capturing on " + selectedDevice.Description + "...");
	                    communicator.ReceivePackets(0, new HandlePacket(this.photonPacketHandler.PacketHandler));
	                }
	            }
	        }
	    }

		private void Form1_FormClosing1(object sender, FormClosingEventArgs e)
		{
			Settings.Default.MeterLoc = this.mForm.Location;
			Settings.Default.FameLoc = this.fForm.Location;
			Settings.Default.MainLoc = base.Location;
			Settings.Default.Save();
			Environment.Exit(Environment.ExitCode);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void Form1_Load_1(object sender, EventArgs e)
		{
		}

		private void lockbutton_Click(object sender, EventArgs e)
		{
			if (this.locked)
			{
				this.locked = !this.locked;
				this.fForm.BackColor = SystemColors.Control;
				this.fForm.TransparencyKey = Color.Transparent;
				this.fForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
				this.mForm.BackColor = SystemColors.Control;
				this.mForm.TransparencyKey = Color.Transparent;
				this.mForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                mForm.pubLabel.ForeColor = Color.FromArgb(30,30,30);
                fForm.pubLabel.ForeColor = Color.FromArgb(30,30,30);
				return;
			}
			this.locked = true;
			this.fForm.BackColor = Color.LightGray;
			this.fForm.TransparencyKey = Color.LightGray;
			this.fForm.FormBorderStyle = FormBorderStyle.None;
			this.mForm.BackColor = Color.LightGray;
			this.mForm.TransparencyKey = Color.LightGray;
			this.mForm.FormBorderStyle = FormBorderStyle.None;
		    mForm.pubLabel.ForeColor = Color.White;
		    fForm.pubLabel.ForeColor = Color.White;
		}

		public FameForm fForm = new FameForm();

		private bool locked;

		public MeterForm mForm = new MeterForm();

		private PhotonPacketHandler photonPacketHandler;

		private PlayerHandler playerHandler;

		private PacketHandler _eventHandler;

		private string _labelText;

		private delegate void updateLabelTextDelegate(string newText);

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
