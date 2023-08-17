using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;

namespace Vadit
{
    public class AppGlobal
    {
        static public bool isinputmode = false;
        static public VdtManager VM = null;
        static public InfoInputCorrectPose CorrectPose = new InfoInputCorrectPose();
        static public Timer TM;
        private static bool _isRunning = false;

        private static FormPopUp _fp = new FormPopUp();
        public static bool LongPlayPopUp = false;

        public static void StartLongPlayPopUp()
        {
                StartTimer();
                _fp.Show();
        }

        public static void StartTimer()
        {
            if (!_isRunning)
            {
                TM = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
                _isRunning = true;
                Debug.WriteLine("Timer started.");
            }
        }
        public static void StopTimer()
        {
            if (_isRunning)
            {
                AppGlobal.TM.Dispose();
                _isRunning = false;
            }
        }
        public static void TimerCallback(object state)
        {
            // 8초마다 실행되는 코드
            Debug.WriteLine("장시간 이용 검출" + DateTime.Now);
  //          _fp.LongUseWarning();
        }
    }
}
