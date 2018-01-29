using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix.MotorControl
{
    public enum RemoteLimitSwitchSource
    {
        RemoteTalonSRX = (1),
        RemoteCANifier = (2),
        Deactivated = (3)
    }
}
