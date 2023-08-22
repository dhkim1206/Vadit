using Emgu.CV;
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
        static public int BadPoseCt = 0;
        static public bool _TimerIsRunning = false;
        static public Timer Timer = null;
        static public bool isinputmode = false;
        static public VdtManager VM = null;
        static public InfoInputCorrectPose CorrectPose = new InfoInputCorrectPose();
        static public TimerManager TM = null;
        static public VideoCapture Cap = null;

    }
}