using System.Diagnostics;

namespace localscrape.SpeedTest
{
    public class SpeedtestService
    {
        public SpeedtestService()
        {

        }

        public string RunSpeedTest()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "speedtest.exe", // Ensure speedtest CLI is installed
                    Arguments = "--format=json", // Get JSON output
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory= @"C:\\Users\\noti_\\Downloads\\ookla-speedtest-1.2.0-win64"
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    return process.StandardOutput.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error running speed test: " + ex.Message);
                return null;
            }
        }

        public double ParseSpeed(string jsonOutput)
        {
            try
            {
                // Find the "download" speed value
                int index = jsonOutput.IndexOf("\"download\":") + 11;
                string substring = jsonOutput.Substring(index);
                string speedString = substring.Split(',')[0].Trim();
                double speed = double.Parse(speedString) / 1_000_000; // Convert from bps to Mbps
                return speed;
            }
            catch
            {
                return 0;
            }
        }
    }
}
