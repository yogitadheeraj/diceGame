using System;
using System.IO;
using System.Windows.Forms;

namespace Dice_Game
{
	static class ErrorLogger
	{
		public static void WriteToErrorLog(string msg, string stkTrace, string title)
		{
			if (!(System.IO.Directory.Exists(Application.StartupPath + "\\Errors\\")))
			{
				System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Errors\\");
			}

			FileStream fs = new FileStream(Application.StartupPath + "\\Errors\\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

			StreamWriter s = new StreamWriter(fs);

			s.Close();

			fs.Close();

			FileStream fs1 = new FileStream(Application.StartupPath + "\\Errors\\errlog.txt", FileMode.Append, FileAccess.Write);

			StreamWriter s1 = new StreamWriter(fs1);

			s1.Write("Title: " + title);

			s1.Write("Message: " + msg);

			s1.Write("StackTrace: " + stkTrace);

			s1.Write("Date/Time: " + DateTime.Now.ToString());

			s1.Write("============================================");

			s1.Close();

			fs1.Close();

		}

	}
}
