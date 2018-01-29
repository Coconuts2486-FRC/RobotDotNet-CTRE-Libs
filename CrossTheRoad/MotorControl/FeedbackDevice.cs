using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix.MotorControl
{
    public enum FeedbackDevice
    {
        None = (-1),

        QuadEncoder = (0),
        Analog = (2),
        Tachometer = (4),
        PulseWidthEncodedPosition = (8),

        SensorSum = (9),
        SensorDifference = (10),
        RemoteSensor0 = (11),
        RemoteSensor1 = (12),
        SoftwareEmulatedSensor = (15),

        CTRE_MagEncoder_Absolute = (8),
        CTRE_MagEncoder_Relative = (0)
    }
}
