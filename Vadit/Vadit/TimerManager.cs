using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using Timer = System.Threading.Timer;

namespace Vadit
{
    public class TimerManager
    {
        private string _configFilePath = "data.xml";
        Timer _timer;
        public TimerManager(Timer timer)
        {
            _timer = timer;
        }
        public void StartTimer()
        {
            if (!AppGlobal._TimerIsRunning)
            {
                _timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(3600));
                Debug.WriteLine("Timer started.");
                AppGlobal._TimerIsRunning = true;
            }
        }
        public void StopTimer()
        {
            if (AppGlobal._TimerIsRunning)
            {
                _timer.Dispose();
                AppGlobal._TimerIsRunning = false;
            }
        }
        public void ShowPoseAlrarm()
        {
            int frequency = -1; // Default value in case of an error
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_configFilePath);

                XmlNode camFrame = doc.SelectSingleNode("//CamFrame");
                if (camFrame != null)
                {
                    int camFrameValue = Convert.ToInt32(camFrame.InnerText);
                    switch (camFrameValue)
                    {
                        case 0:
                            frequency = 0;
                            break;
                        case 1:
                            frequency = 1;
                            break;
                        case 2:
                            frequency = 3;
                            break;
                        default:
                            Debug.WriteLine("Invalid CamFrame value");
                            return; // Invalid value
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle XML reading error
                Console.WriteLine("Error reading config file: " + ex.Message);
            }
            if (AppGlobal.BadPoseCt > frequency)
            {
                FormPopUp _formpup = new FormPopUp();
                _formpup.Show();
                _formpup.OpenUserImage(AppBase.AppConf.ConfigSet.NotificationLayout);
                _formpup.ShowLayout(AppBase.AppConf.ConfigSet.NotificationLayout);
                Application.DoEvents();
                Thread.Sleep(6000);
                _formpup.Close();
                Debug.WriteLine("나쁜자세 5회 이상 적발. 알림 후 초기화");
                AppGlobal.BadPoseCt = 0;
                return;
            }
            else if (AppGlobal.BadPoseCt > frequency)
            {
                FormPopUp _formpup = new FormPopUp();
                _formpup.Show();
                _formpup.OpenUserImage(AppBase.AppConf.ConfigSet.NotificationLayout);
                _formpup.ShowLayout(AppBase.AppConf.ConfigSet.NotificationLayout);
                Application.DoEvents();
                Thread.Sleep(3000);
                _formpup.Close();
                Debug.WriteLine("나쁜자세 3회 이상 적발. 알림 후 초기화");
                AppGlobal.BadPoseCt = 0;
                return;
            }
            else if (AppGlobal.BadPoseCt > frequency)
            {
                FormPopUp _formpup = new FormPopUp();
                _formpup.Show();
                _formpup.OpenUserImage(AppBase.AppConf.ConfigSet.NotificationLayout);
                _formpup.ShowLayout(AppBase.AppConf.ConfigSet.NotificationLayout);
                Application.DoEvents();
                Thread.Sleep(3000);
                _formpup.Close();
                Debug.WriteLine("나쁜자세 적발. 알림 후 초기화");
                AppGlobal.BadPoseCt = 0;
                return;
            }
            AppGlobal.BadPoseCt++;
            Debug.WriteLine("나쁜자세 누적 횟수:" + AppGlobal.BadPoseCt);
        }
        public void TimerCallback(object state)
        {

            // 8초마다 실행되는 코드
            Debug.WriteLine("장시간 이용 검출" + DateTime.Now);
            FormPopUp _fp = new FormPopUp();

            Thread.Sleep(360000);
            _fp.Show();
            _fp.LongPalyPopUp();
            _fp.Close();

        }
    }
}
