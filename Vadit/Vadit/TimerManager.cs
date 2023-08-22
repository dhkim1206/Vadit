using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Threading.Timer;

namespace Vadit
{
    public class TimerManager
    {
        Timer _timer;
        public TimerManager(Timer timer)
        {
            _timer = timer;

        }
        public void StartTimer()
        {
            if (!AppGlobal._TimerIsRunning)
            {            
                _timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
                Debug.WriteLine("Timer started.");
                AppGlobal._TimerIsRunning = true;
                
            }
        }
        public void StopTimer()
        {
            if (AppGlobal._TimerIsRunning && AppGlobal.Timer != null)
            {
                _timer.Dispose();
                AppGlobal._TimerIsRunning = false;
            }
        }
        public void ShowPoseAlrarm()
        {
            if (AppGlobal.BadPoseCt > 3)
            {
                FormPopUp _formpup = new FormPopUp();
                _formpup.Show();
                _formpup.OpenUserImage(AppBase.AppConf.ConfigSet.NotificationLayout);
                _formpup.SetLayout(AppBase.AppConf.ConfigSet.NotificationLayout);
                Application.DoEvents();
                Thread.Sleep(3000);
                _formpup.Close();
                Debug.WriteLine("나쁜자세 4회 이상 적발. 알림 후 초기화");
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
            _fp.Show();
            _fp.LongPalyPopUp();
            Thread.Sleep(3000);
            _fp.Close();

        }
    }
}
