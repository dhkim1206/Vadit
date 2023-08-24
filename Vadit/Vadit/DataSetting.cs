using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vadit
{
    public enum EnumNotificationLayout
    {
        Standard,
        OnlyUser,
        Text
    }

    [Serializable]
    public class AppConfigClass
    {
        public bool Pose;
        public bool LongPlay;
        public bool WindowSameExecute;
        public bool AlarmSound;
        public int CamFrame;
        public int SaveingPeriod; // 위에서 부터 1, 2, 3 ...
        public EnumNotificationLayout NotificationLayout; //Convert.ToInt32(AppConf.ConfigSet.NotificationLayout);

    }
}
