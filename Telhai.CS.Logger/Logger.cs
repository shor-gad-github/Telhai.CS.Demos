namespace Telhai.CS.Logging
{
    public class Logger
    {
        public static void Log(string txt)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.WriteLine(txt +
                            "\n--------------------------------");
            }
        }
    }
}