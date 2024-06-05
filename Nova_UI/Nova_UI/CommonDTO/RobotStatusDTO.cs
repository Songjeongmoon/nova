using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nova_UI.CommonDTO
{
    public class RobotStatusDTO
    {
        public int batteryPercentage { get; set; }
        public string dockingStatus { get; set; }
        public bool insCharging { get; set; }
        public bool isDCConnected { get; set; }
        public string powerStage { get; set; }
        public string sleepMode { get; set; }
    }
}
