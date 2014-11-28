using System;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{
		private static void SaveData(string s, byte[] d)
		{
		    SaveFile(s, d);
		    SaveFile(Path.ChangeExtension(s, "bkp"), d);
		    SaveTime(s);
		}

	    private static void SaveTime(string s)
	    {
            string tf = s + ".time";
            var fs3 = new FileStream(tf, FileMode.OpenOrCreate);
            var t = BitConverter.GetBytes(DateTime.Now.Ticks);
			fs3.Write(t, 0, t.Length);
			fs3.Close();
	    }

	    private static void SaveFile(string filename, byte[] d)
        {
            var fs = new FileStream(filename, FileMode.OpenOrCreate);
            fs.Write(d, 0, d.Length);
            fs.Close();
	    }
	}
}