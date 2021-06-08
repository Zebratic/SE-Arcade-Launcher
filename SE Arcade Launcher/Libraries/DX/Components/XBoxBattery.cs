﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Arcade_Launcher.Libraries.DX
{
    public enum BatteryLevel : byte { Empty = 0, Low = 1, Medium = 2, Full = 3 };

    public class XBoxBattery : XBoxComponent<BatteryLevel>
    {
        public XBoxBattery(BatteryLevel initialLevel = BatteryLevel.Empty) : base(initialLevel) { }
    }
}
