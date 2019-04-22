using System;
using System.Windows.Forms;

namespace AODPSo
{
	internal static class Program
	{
		public static void ErrorLogging(Exception ex)
		{
		}

		[STAThread]
		private static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(true);
				Application.Run(new Form1());
			}
			catch (Exception exception)
			{
				Program.ErrorLogging(exception);
			}
		}
	}
}
