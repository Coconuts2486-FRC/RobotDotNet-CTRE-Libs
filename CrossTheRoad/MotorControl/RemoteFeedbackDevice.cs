using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix.MotorControl
{
    public enum RemoteFeedbackDevice
    {
        None = (-1),

        SensorSum = (9),
        SensorDifference = (10),
        RemoteSensor0 = (11),
        RemoteSensor1 = (12),
        SoftwareEmulatedSensor = (15)
    }
}
