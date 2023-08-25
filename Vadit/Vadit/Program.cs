using System.Xml;

namespace Vadit
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            SplashScreen splash = new SplashScreen();

            splash.ShowDialog();
            string _configFilePath = "data.xml";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_configFilePath);

                XmlNode poseNode = doc.SelectSingleNode("//Pose");
                if (poseNode != null)
                {
                    int saveingPeriodValue = Convert.ToInt32(poseNode.InnerText);
                    switch (saveingPeriodValue)
                    {
                        case 0:
                            return 15;
                        case 1:
                            return 30;
                        case 2:
                            return 90;
                        default:
                            return -1; // Invalid value
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle XML reading error
                Console.WriteLine("Error reading config file: " + ex.Message);
            }

            Application.Run(new FormMain());
        }
    }
}