using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vadit
{
    public class SettingData
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
            public int SaveingPeriod;
            public int CamFrame;
            public EnumNotificationLayout NotificationLayout;

        }
    }
}
